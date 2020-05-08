using System.Web.Mvc;
using System.Web.Routing;

namespace BookStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Book",
                    action = "List",
                    genre = (string)null,
                    page = 1
                }
            );
            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Book", action = "List", genre = (string)null },
                constraints: new { page = @"\d+" }
            );
            routes.MapRoute(null,
                "{genre}",
                new { controller = "Book", action = "List", page = 1 }
            );
            routes.MapRoute(null,
                "{genre}/Page{page}",
                new { controller = "Book", action = "List" },
                new { page = @"\d+" }
            );
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
