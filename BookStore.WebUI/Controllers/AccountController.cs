using System;
using System.Collections.Generic;
using BookStore.Domain.Entities;
using BookStore.Domain.Abstract;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BookStore.WebUI.Models;

namespace BookStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        public IUserRepository userRepository;
        public IOrderProcessorDb purchaseRepository;
        public IBookRepository bookRepository;
        public IDeliveryDetailsRepository deliveryDetailsRepository;
        
        public AccountController(IUserRepository userRepo, IOrderProcessorDb purchaseRepo,
            IBookRepository bookRepo, IDeliveryDetailsRepository deliveryDetailsRepo)
        {
            userRepository = userRepo;
            purchaseRepository = purchaseRepo;
            bookRepository = bookRepo;
            deliveryDetailsRepository = deliveryDetailsRepo;
        }
        public ViewResult ProfileInfoChanges() => View();
        public ActionResult Index()
        {
            var user = userRepository.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
            return View(user);
        }
        public ViewResult EditProfile(int userId)
        {
            var user = userRepository.Users.FirstOrDefault(u => u.UserId == userId);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditProfile(User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.SaveUser(user);
                TempData["message"] = string.Format("Изменения в профиле были сохранены");
                FormsAuthentication.SignOut();
                return RedirectToAction("ProfileInfoChanges");
            }
            else
                return View(user);
        }
        public ViewResult EditPassword(int userId)
        {
            var user = userRepository.Users.FirstOrDefault(u => u.UserId == userId);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditPassword(int userId, string oldPass, string newPass)
        {
            var user = userRepository.Users.FirstOrDefault(u => u.UserId == userId);
            if (ModelState.IsValid)
            {
                if (oldPass == newPass)
                    ModelState.AddModelError("", "Текущий и новый пароли. Изменение невозможно.");
                else if (user.Password == oldPass)
                {
                    userRepository.ChangePassword(user, newPass);
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
        public ViewResult Purchases(int userId)
        {
            var purchases = purchaseRepository.Purchases.Where(p => p.UserId == userId);     
            return View(purchases);
        }
        public ActionResult PurchaseDetails(int orderId)
        {
            var purchases = purchaseRepository.Purchases.Where(p => p.OrderId == orderId);
            return PartialView(purchases);
        }
        public ActionResult DeliveryDetails(int orderId)
        {
            var deliveryDetails = deliveryDetailsRepository.DeliveryDetails.Where(d=>d.OrderId== orderId);
            return PartialView(deliveryDetails);
        }
    }
}