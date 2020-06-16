using System.Linq;
using System.Web.Mvc;
using BookStore.WebUI.Models;
using BookStore.Domain.Entities;
using BookStore.Domain.Concrete;
using System.Web.Security;

namespace BookStore.WebUI.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Register() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (var db = new EFDbContext())
                    user = db.Users.FirstOrDefault(u => u.Email == model.UserName);
                if (user == null)
                {
                    using (var db = new EFDbContext())
                    {
                        db.Users.Add(new User
                        {
                            Email = model.UserName,
                            Password = model.Password,
                            Name = model.Name,
                            Age = model.Age,
                            RoleId = 2
                        });
                        db.SaveChanges();
                        user = db.Users.Where(u => u.Email == model.UserName && u.Password == model.Password).FirstOrDefault();
                    }
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, true);
                        return RedirectToAction("List", "Book");
                    }
                }
                else
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
            }
            return View(model);
        }
        public ActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (var db = new EFDbContext())
                    user = db.Users
                        .FirstOrDefault(u => u.Email == model.UserName
                        && u.Password == model.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                    return RedirectToAction("List", "Book");
                }
                else
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
            }
            return View(model);
        }
        public ActionResult Logout() => View();
    }
}