using System.Web.Mvc;
using BookStore.WebUI.Filters;

namespace BookStore.WebUI.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogAttribute());
        }
    }
}