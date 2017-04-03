using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CM.Payments.Client.SampleWebApp.ActionFilters;
using CM.Payments.Client.SampleWebApp.Context;
using CM.Payments.Client.SampleWebApp.Models;

namespace CM.Payments.Client.SampleWebApp.Controllers
{
    [Route("{action=Index}")]
    public class HomeController : Controller
    {
        private readonly SampleAppContext _context = new SampleAppContext();

        [CustomAuthorize]
        [Route("Cart")]
        public ActionResult Cart()
        {
            return this.View(this.GetOrder());
        }

        [CustomAuthorize]
        [Route("Products/{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = this._context.Products.Find(id);
            if (product == null)
            {
                return this.HttpNotFound();
            }
            return this.View(product);
        }

        [HttpPost]
        [Route("Products/{id:int}")]
        public ActionResult Details(int id, int quantity)
        {
            var cart = this.GetOrder();
            var account = this.GetUser();
            if (cart == null)
            {
                cart = new Order {Created = DateTime.Now, Status = Status.Open};
                account.Orders.Add(cart);
                this._context.SaveChanges();
                this.Session["CartId"] = cart.Id;
            }
            var product = this._context.Products.Find(id);
            if (product == null)
            {
                return this.HttpNotFound();
            }

            var item = this._context.OrderItems.FirstOrDefault(w => w.OrderId == cart.Id && w.ProductId == product.Id);
            if (item == null)
            {
                item = new OrderItem {AddedOn = DateTime.Now, Quantity = quantity, ProductId = product.Id, OrderId = cart.Id};
                this._context.OrderItems.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }

            this._context.SaveChanges();
            this.Session["Amount"] = cart.OrderItems.Count();
            return this.Json(cart.OrderItems.Count(), JsonRequestBehavior.AllowGet);
        }

        public Order GetOrder()
        {
            var id = 0;
            if (this.Session["CartId"] != null)
            {
                id = (int) this.Session["CartId"];
            }
            return this._context.Orders.Find(id);
        }

        public Account GetUser()
        {
            var account = (Account) this.Session["User"];
            return this._context.Accounts.Find(account.Id);
        }

        [CustomAuthorize]
        public ActionResult Index(int page = 1)
        {
            var account = this.Session["User"] as Account;
            if (this.Session["CartId"] == null)
            {
                var order =
                    this._context.Orders.OrderByDescending(w => w.Status).FirstOrDefault(w => w.Status == Status.Open && w.AccountId == account.Id);
                this.Session["CartId"] = order?.Id;
                this.Session["Amount"] = order?.OrderItems.Count();
            }

            var pageSize = 8;
            this.ViewBag.PageCount = (this._context.Products.Count() + pageSize - 1) / pageSize;
            this.ViewBag.Current = page;

            var products = this._context.Products.OrderBy(w => w.Id).Skip(page * pageSize - pageSize).Take(pageSize).ToList();

            return this.View(products);
        }

        [Route("Login")]
        public ActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Username,Password,HasError")] LoginModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = this._context.Accounts.FirstOrDefault(w => w.Username.ToLower() == model.Username.ToLower());

            if (user == null)
            {
                this.ModelState.AddModelError("", "Wrong username or password.");
                return this.View(model);
            }

            if (user.Password != model.Password)
            {
                this.ModelState.AddModelError("", "Wrong username or password.");
                return this.View(model);
            }

            this.Session["User"] = user;
            this.Session["Username"] = user.Username;
            return this.RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            this.Session["User"] = null;
            return this.RedirectToAction("Login");
        }
    }
}