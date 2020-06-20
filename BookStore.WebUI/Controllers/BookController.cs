using System.Linq;
using System.Web.Mvc;
using BookStore.Domain.Abstract;
using BookStore.WebUI.Models;

namespace BookStore.WebUI.Controllers
{
    public class BookController : Controller
    {
        public int pageSize = 4;
        public IBookRepository repository;
        public BookController(IBookRepository repo) => repository = repo;
        public ViewResult List(string genre, int page = 1)
        {
            BooksListViewModel model = new BooksListViewModel
            {
                Books = repository.Books
                .Where(p => genre == null || p.Genre == genre)
                .OrderBy(b => b.BookId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = genre == null ?
                    repository.Books.Count()
                    : repository.Books.Where(b => b.Genre == genre).Count()
                },
                CurrentGenre = genre
            };
            return View(model);
        }
        public FileContentResult GetImage(int bookId)
        {
            var book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
                return File(book.ImageData, book.ImageMimeType);
            else
                return null;
        }
    }
}