using System.Linq;
using System.Web.Mvc;
using BookStore.Domain.Entities;
using BookStore.Domain.Abstract;
using BookStore.WebUI.Models;

namespace BookStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IBookRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IBookRepository repo, IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }
        public CartController(IBookRepository repo) => repository = repo;
        public ViewResult Checkout() => View(new DeliveryDetails());
        [HttpPost]
        public ViewResult Checkout(Cart cart,DeliveryDetails deliveryDetails)
        {
            if (cart.Lines.Count() == 0)
                ModelState.AddModelError("","Извините,ваша корзина пуста.");
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, deliveryDetails);
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
            Book book = repository.Books.Where(b => b.BookId == bookId).FirstOrDefault();
            if (book != null)  
                cart.AddItem(book, 1);
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int bookId, string returnUrl)
        {
            Book book = repository.Books.Where(b => b.BookId == bookId).FirstOrDefault();
            if (book != null)
                cart.RemoveLine(book);
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}