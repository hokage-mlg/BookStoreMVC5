using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BookStore.Domain.Abstract;
using BookStore.Domain.Concrete;

namespace BookStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        IBookRepository repository;
        EFDbContext db = new EFDbContext();
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
        public PartialViewResult SearchPanel() => PartialView();
        [HttpPost]
        public ActionResult BookSearch(string name)
        {
            var allbooks = db.Books.Where(a => a.Author.Contains(name) || a.Title.Contains(name)).ToList();
            if (allbooks.Count <= 0)
                return PartialView("NotFound");
            return PartialView(allbooks);
        }
    }
}