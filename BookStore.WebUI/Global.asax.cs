using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using BookStore.Domain.Concrete;
using BookStore.WebUI.App_Start;
using BookStore.Domain.Entities;
using BookStore.WebUI.Infrastructure.Binders;

namespace BookStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new UserDbInitializer());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
