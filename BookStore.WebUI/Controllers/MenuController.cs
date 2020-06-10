using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class MenuController : Controller
    {       
        public ActionResult Author() => View();
        public ActionResult Wholesale() => View();
        public ActionResult Cooperation() => View();
        public ActionResult News() => View();
        public ActionResult About() => View();
    }
}