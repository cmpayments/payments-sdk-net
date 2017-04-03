using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebPages;
using CM.Payments.Client.Enums;
using CM.Payments.Client.Model;
using CM.Payments.Client.SampleWebApp.Context;
using CM.Payments.Client.SampleWebApp.Models;

namespace CM.Payments.Client.SampleWebApp.Controllers
{
    public sealed class CheckoutController : Controller
    {
        private readonly PaymentClient _client;
        private readonly SampleAppContext _context = new SampleAppContext();

        public CheckoutController()
        {
            if (string.IsNullOrEmpty(ConsumerKey) || string.IsNullOrEmpty(ConsumerSecret))
            {
                throw new InvalidOperationException("Consumer key and/or secret are not specified. Please review the web.config file.");
            }

            this._client = new PaymentClient(ConsumerKey, ConsumerSecret);
        }

        private static string ConsumerKey => ConfigurationManager.AppSettings["Consumer.Key"];
        private static string ConsumerSecret => ConfigurationManager.AppSettings["Consumer.Secret"];

        [Route("Checkout/Failed")]
        public ActionResult Failed()
        {
            return this.View();
        }

        public string GetIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            return (from ip in host.AddressList where ip.AddressFamily == AddressFamily.InterNetwork select ip.ToString()).FirstOrDefault();
        }

        [Route("Checkout/Details")]
        public ActionResult Index()
        {
            if (this.Session["Details"] != null)
            {
                return this.RedirectToAction("Method");
            }
            this.ViewBag.Order = this._context.Orders.Find((int) this.Session["CartId"]);

            return this.View();
        }

        [HttpPost]
        [Route("Checkout/Details")]
        public ActionResult Index([Bind(Include = "FirstName,LastName,PostalCode,Email,City,DateOfBirth,PhoneNumber,Address")] OrderModel model)
        {
            this.ViewBag.Order = this._context.Orders.Find((int) this.Session["CartId"]);
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            this.Session["Details"] = model;
            return this.RedirectToAction("Method");
        }

        [Route("Checkout/Method")]
        public ActionResult Method(string status)
        {
            this.ViewBag.Status = status.IsEmpty() ? "" : status;
            return this.View();
        }

        [HttpPost]
        [Route("Checkout/Method")]
        public async Task<ActionResult> Method(string method, string data)
        {
            var orderId = this.Session["CartId"];
            var order = this._context.Orders.Find(orderId);
            if (order == null)
            {
                return this.HttpNotFound();
            }

            var model = (OrderModel) this.Session["Details"];

            var charge = new ChargeRequest {Amount = order.GetTotalCost(), Currency = "EUR"};

            switch (method)
            {
                case "ideal":
                    charge.Payments = new List<PaymentRequest>
                    {
                        new IdealPaymentRequest
                        {
                            Amount = order.GetTotalCost(),
                            Currency = "EUR",
                            Details =
                                new IdealDetailsRequest
                                {
                                    IssuerId = data,
                                    SuccessUrl = this.Url.Action("Success", "Checkout", null, this.Request.Url?.Scheme),
                                    FailedUrl = this.Url.Action("Failed", null, null, this.Request.Url?.Scheme),
                                    CancelledUrl = this.Url.Action("Method", null, new {status = "cancelled"}, this.Request.Url?.Scheme),
                                    ExpiredUrl = "",
                                    PurchaseId = Guid.NewGuid().ToString("N"),
                                    Description = "Test description."
                                }
                        }
                    };
                    break;
                case "paypal":
                    charge.Payments = new List<PaymentRequest>
                    {
                        new PayPalPaymentRequest
                        {
                            Amount = order.GetTotalCost(),
                            Currency = "EUR",
                            Details =
                                new PayPalDetailsRequest
                                {
                                    SuccessUrl = this.Url.Action("Success", "Checkout", null, this.Request.Url?.Scheme),
                                    FailedUrl = this.Url.Action("Failed", null, null, this.Request.Url?.Scheme),
                                    CancelledUrl = this.Url.Action("Method", null, new {status = "cancelled"}, this.Request.Url?.Scheme),
                                    ExpiredUrl = "",
                                    PurchaseId = Guid.NewGuid().ToString("N"),
                                    Description = "Test description."
                                }
                        }
                    };
                    break;
                case "afterpay":
                    charge.Payments = new List<PaymentRequest>
                    {
                        new AfterPayPaymentRequest
                        {
                            Amount = order.GetTotalCost(),
                            Currency = "EUR",
                            Details =
                                new AfterPayDetailsRequest
                                {
                                    PortfolioId = 1,
                                    Password = "de6a0cb37f",
                                    BankAccountNumber = "NL55INGB0000000000",
                                    IpAddress = this.GetIp(),
                                    OrderNumber = Guid.NewGuid().ToString("N").Substring(0, 24),
                                    InvoiceNumber = Guid.NewGuid().ToString("N").Substring(0, 15),
                                    TotalOrderAmount = (int) order.GetTotalCost(),
                                    Orderline =
                                        order.OrderItems.Select(
                                            w =>
                                                new AfterPayDetailsRequest.OrderLine
                                                {
                                                    ArticleDescription = w.Product.Description.Substring(0, 45),
                                                    ArticleId = w.Id.ToString(),
                                                    Quantity = w.Quantity,
                                                    UnitPrice = (int) (w.Product.Price * 100),
                                                    NetUnitPrice = (int) (w.Product.Price * 100),
                                                    VatCategory = AfterPayVatCategory.High
                                                }).ToList(),
                                    BillToAddress =
                                        new AfterPayDetailsRequest.OrderAddress
                                        {
                                            City = model.City,
                                            StreetName = model.GetFormattedAddress()[0],
                                            HouseNumber = Convert.ToInt32(model.GetFormattedAddress()[1]),
                                            IsoCountryCode = "NL",
                                            PostalCode = model.PostalCode,
                                            Region = "Zuid-Holland",
                                            Reference =
                                                new AfterPayDetailsRequest.OrderAddress.ReferencePerson
                                                {
                                                    LastName = model.LastName,
                                                    Initials = model.GetInitials(),
                                                    EmailAddress = model.Email,
                                                    PhoneNumber1 = model.PhoneNumber,
                                                    PhoneNumber2 = model.PhoneNumber,
                                                    Gender = "M",
                                                    DateOfBirth = model.DateOfBirth,
                                                    IsoLanguage = "NL-BE"
                                                }
                                        },
                                    ShipToAddress =
                                        new AfterPayDetailsRequest.OrderAddress
                                        {
                                            City = model.City,
                                            StreetName = model.GetFormattedAddress()[0],
                                            HouseNumber = Convert.ToInt32(model.GetFormattedAddress()[1]),
                                            IsoCountryCode = "NL",
                                            PostalCode = model.PostalCode,
                                            Region = "Zuid-Holland",
                                            Reference =
                                                new AfterPayDetailsRequest.OrderAddress.ReferencePerson
                                                {
                                                    LastName = model.LastName,
                                                    Initials = model.GetInitials(),
                                                    EmailAddress = model.Email,
                                                    PhoneNumber1 = model.PhoneNumber,
                                                    PhoneNumber2 = model.PhoneNumber,
                                                    Gender = "M",
                                                    DateOfBirth = model.DateOfBirth,
                                                    IsoLanguage = "NL-BE"
                                                }
                                        }
                                }
                        }
                    };
                    break;
                case "creditcard":
                    charge.Payments = new List<PaymentRequest>
                    {
                        new CreditcardPaymentRequest
                        {
                            Amount = order.GetTotalCost(),
                            Currency = "EUR",
                            Capture = true,
                            Details =
                                new CreditcardDetailsRequest
                                {
                                    Issuers = new[] {"MasterCard", "VISA"},
                                    SuccessUrl = this.Url.Action("Success", "Checkout", null, this.Request.Url?.Scheme),
                                    FailedUrl = this.Url.Action("Failed", null, null, this.Request.Url?.Scheme),
                                    CancelledUrl = this.Url.Action("Method", null, new {status = "cancelled"}, this.Request.Url?.Scheme),
                                    ExpiredUrl = "",
                                    PurchaseId = Guid.NewGuid().ToString("N")
                                }
                        }
                    };
                    break;
                case "sofort":
                    charge.Payments = new List<PaymentRequest>
                    {
                        new SofortPaymentRequest
                        {
                            Amount = order.GetTotalCost(),
                            Currency = "EUR",
                            Details =
                                new SofortDetailsRequest
                                {
                                    BankBic = data,
                                    BankAccountNumber = "NL55INGB0000000000",
                                    ConsumerName = "Barteljaap Gustaaf",
                                    SuccessUrl = this.Url.Action("Success", "Checkout", null, this.Request.Url?.Scheme),
                                    FailedUrl = this.Url.Action("Failed", null, null, this.Request.Url?.Scheme),
                                    CancelledUrl = this.Url.Action("Method", null, new {status = "cancelled"}, this.Request.Url?.Scheme),
                                    ExpiredUrl = "",
                                    PurchaseId = Guid.NewGuid().ToString("N"),
                                    Description = "Test description"
                                }
                        }
                    };
                    break;
                case "bancontact":
                    charge.Payments = new List<PaymentRequest>
                    {
                        new BancontactPaymentRequest
                        {
                            Amount = order.GetTotalCost(),
                            Currency = "EUR",
                            Details =
                                new BancontactDetailsRequest
                                {
                                    SuccessUrl = this.Url.Action("Success", "Checkout", null, this.Request.Url?.Scheme),
                                    FailedUrl = this.Url.Action("Failed", null, null, this.Request.Url?.Scheme),
                                    CancelledUrl = this.Url.Action("Method", null, new {status = "cancelled"}, this.Request.Url?.Scheme),
                                    ExpiredUrl = "",
                                    PurchaseId = Guid.NewGuid().ToString("N")
                                }
                        }
                    };
                    break;
                case "wiretransfer":
                    charge.Payments = new List<PaymentRequest>
                    {
                        new WireTransferPaymentRequest
                        {
                            Amount = order.GetTotalCost(),
                            Currency = "EUR",
                            ExpiredAt = DateTime.Now.AddDays(2),
                            Details = new WireTransferDetailsRequest {PurchaseId = Guid.NewGuid().ToString("N")}
                        }
                    };
                    break;
            }

            var response = await this.ProceedPaymentAsync(charge);

            return this.Json(new {AuthUrl = response.Payments.FirstOrDefault()?.Details.AuthenticationUrl});
        }

        public async Task<ChargeResponse> ProceedPaymentAsync(ChargeRequest charge)
        {
            return await this._client.PayAsync(charge).ConfigureAwait(false);
        }

        [Route("Checkout/Success")]
        public ActionResult Success()
        {
            if (this.Session["CartId"] == null)
            {
                return this.RedirectToAction("Index", "Home");
            }
            var orderId = this.Session["CartId"];
            var order = this._context.Orders.Find(orderId);

            if (order == null)
            {
                return this.HttpNotFound();
            }

            order.Status = Status.Paid;
            order.PaidOn = DateTime.Now;
            this._context.SaveChanges();
            this.Session["CartId"] = null;
            this.Session["Details"] = null;
            this.Session["Amount"] = null;
            return this.View();
        }
    }
}