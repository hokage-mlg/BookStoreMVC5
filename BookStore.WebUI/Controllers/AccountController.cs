using BookStore.Domain.Entities;
using BookStore.Domain.Abstract;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

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
                if (newPass == "")
                    ModelState.AddModelError("", "Вы не ввели новый пароль. Изменение невозможно.");
                else if (oldPass == newPass)
                    ModelState.AddModelError("", "Текущий и новый пароли совпадают. Изменение невозможно.");
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
        public ActionResult PurchaseDetails(int deliveryDetailsId)
        {
            var purchases = purchaseRepository.Purchases.Where(p => p.DeliveryDetailsId == deliveryDetailsId);
            return PartialView(purchases);
        }
        public ActionResult DeliveryDetails(int deliveryDetailsId)
        {
            var deliveryDetails = deliveryDetailsRepository.DeliveryDetails.Where(d => d.DeliveryDetailsId == deliveryDetailsId).FirstOrDefault();
            return PartialView(deliveryDetails);
        }
        [HttpPost]
        public RedirectToRouteResult ConfirmReceipt(int deliveryDetailsId, string returnUrl, int userId)
        {
            var purchases = purchaseRepository.Purchases.Where(p => p.DeliveryDetailsId == deliveryDetailsId).ToList();
            if (purchases != null)
                foreach (var p in purchases)
                    purchaseRepository.ChangeDeliveryStatus(p.OrderLineId, "Получен");
            return RedirectToAction("Purchases", new { returnUrl, userId });
        }
    }
}