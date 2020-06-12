using System;
using System.Collections.Generic;
using BookStore.Domain.Entities;
using BookStore.Domain.Abstract;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        public IUserRepository repository;
        public AccountController(IUserRepository repo) => repository = repo;
        public ViewResult ProfileInfoChanges() => View();
        public ActionResult Index()
        {
            var user = repository.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
            return View(user);
        }
        public ViewResult EditProfile(int userId)
        {
            var user = repository.Users.FirstOrDefault(u => u.UserId == userId);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditProfile(User user)
        {
            if (ModelState.IsValid)
            {
                repository.SaveUser(user);
                TempData["message"] = string.Format("Изменения в профиле были сохранены");
                FormsAuthentication.SignOut();
                return RedirectToAction("ProfileInfoChanges");
            }
            else
                return View(user);
        }
        public ViewResult EditPassword(int userId)
        {
            var user = repository.Users.FirstOrDefault(u => u.UserId == userId);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditPassword(int userId, string oldPass, string newPass)
        {
            var user = repository.Users.FirstOrDefault(u => u.UserId == userId);
            if (ModelState.IsValid)
            {
                if (oldPass == newPass)
                    ModelState.AddModelError("", "Текущий и новый пароли. Изменение невозможно.");
                else if (user.Password == oldPass)
                {
                    repository.ChangePassword(user, newPass);
                    TempData["message"] = string.Format("Изменения в профиле были сохранены");
                    FormsAuthentication.SignOut();
                    return RedirectToAction("ProfileInfoChanges");
                }               
                else
                    ModelState.AddModelError("", "Вы ввели неверный текущий пароль. Изменение невозможно.");
                return View(user);
            }
            else
                return View(user);
        }
    }
}