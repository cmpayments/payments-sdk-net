using System.Web.Mvc;

namespace CM.Payments.Client.SampleWebApp
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}