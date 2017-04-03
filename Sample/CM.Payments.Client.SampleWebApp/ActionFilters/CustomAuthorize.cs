using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CM.Payments.Client.SampleWebApp.ActionFilters
{
    public sealed class CustomAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {{"controller", "Home"}, {"action", "Login"}});
            }
            base.OnActionExecuting(filterContext);
        }
    }
}