using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BookStore.Domain.Abstract;

namespace BookStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        IBookRepository repository;
        public NavController(IBookRepository repo) => repository = repo;
        public PartialViewResult Menu(string genre = null)
        {
            ViewBag.SelectedGenre = genre;
            IEnumerable<string> genres = repository.Books
                .Select(b => b.Genre)
                .Distinct()
                .OrderBy(x => x);
            return PartialView("FlexMenu", genres);
        }
    }
}