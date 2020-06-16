using System;
using System.Web.Mvc;
using BookStore.Domain.Entities;
using BookStore.Domain.Concrete;

namespace BookStore.WebUI.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var visitor = new Visitor()
            {
                Ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                Url = request.RawUrl,
                Date = DateTime.UtcNow
            };
            using (var db = new EFDbContext())
            {
                db.Visitors.Add(visitor);
                db.SaveChanges();
            }
            base.OnActionExecuting(filterContext);
        }
    }
}