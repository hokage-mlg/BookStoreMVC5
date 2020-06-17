using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Domain.Entities;
using BookStore.Domain.Abstract;

namespace BookStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        public IBookRepository bookRepository;
        public IUserRepository userRepository;
        public IDeliveryDetailsRepository deliveryDetailsRepository;
        public IOrderProcessorDb purchaseRepository;
        public AdminController(IBookRepository bookRepo, IUserRepository userRepo,
            IOrderProcessorDb purchaseRepo, IDeliveryDetailsRepository deliveryDetailsRepo)
        {
            bookRepository = bookRepo;
            userRepository = userRepo;
            purchaseRepository = purchaseRepo;
            deliveryDetailsRepository = deliveryDetailsRepo;
        }
        public ViewResult Index() => View();
        public ActionResult BookList() => PartialView(bookRepository.Books);
        public ActionResult UserList() => PartialView(userRepository.Users);
        public ActionResult PurchaseList() => PartialView(purchaseRepository.Purchases);
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
        public ViewResult Edit(int bookId)
        {
            var book = bookRepository.Books.FirstOrDefault(b => b.BookId == bookId);
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    book.ImageMimeType = image.ContentType;
                    book.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(book.ImageData, 0, image.ContentLength);
                }
                bookRepository.SaveBook(book);
                TempData["message"] = string.Format("Изменения в книге \"{0}\" были сохранены", book.Title);
                return RedirectToAction("Index");
            }
            else
                return View(book);
        }
        public ViewResult Create() => View("Edit", new Book());
        [HttpPost]
        public ActionResult Delete(int bookId)
        {
            var deletedBook = bookRepository.DeleteBook(bookId);
            if (deletedBook != null)
                TempData["message"] = string.Format("Книга \"{0}\" была удалена",
                    deletedBook.Title);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult GiveRole(int userId, int roleId)
        {
            var changedUser = userRepository.GiveRole(userId, roleId);
            if (changedUser != null)
                TempData["message"] = string.Format("Роль пользователя \"{0}\" была изменена",
                    changedUser.Email);
            return RedirectToAction("Index");
        }
    }
}