using System.Linq;
using System.Web.Mvc;
using BookStore.Domain.Entities;
using BookStore.Domain.Abstract;
using BookStore.WebUI.Models;

namespace BookStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IBookRepository bookRepository;
        private IDeliveryDetailsRepository deliveryDetailsRepository;
        private IOrderProcessor orderProcessor;
        private IOrderProcessorDb orderProcessorDB;
        public CartController(IBookRepository bookRepo, IOrderProcessor proc,
            IDeliveryDetailsRepository delDetRepo, IOrderProcessorDb procDB)
        {
            bookRepository = bookRepo;
            deliveryDetailsRepository = delDetRepo;
            orderProcessor = proc;
            orderProcessorDB = procDB;
        }
        public CartController(IBookRepository repo) => bookRepository = repo;
        public ViewResult Checkout() => View(new DeliveryDetails());
        [HttpPost]
        public ViewResult Checkout(Cart cart,DeliveryDetails deliveryDetails)
        {
            if (cart.Lines.Count() == 0)
                ModelState.AddModelError("","Извините,ваша корзина пуста.");
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, deliveryDetails);
                deliveryDetailsRepository.SaveDeliveryDetails(deliveryDetails);
                orderProcessorDB.ProcessOrderDB(cart, deliveryDetails);
                cart.Clear();
                return View("Completed");
            }
            else
                return View(deliveryDetails);
        }
        public PartialViewResult Summary(Cart cart) => PartialView(cart);
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int bookId, string returnUrl)
        {
            Book book = bookRepository.Books.Where(b => b.BookId == bookId).FirstOrDefault();
            if (book != null)  
                cart.AddItem(book, 1);
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int bookId, string returnUrl)
        {
            Book book = bookRepository.Books.Where(b => b.BookId == bookId).FirstOrDefault();
            if (book != null)
                cart.RemoveLine(book);
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}