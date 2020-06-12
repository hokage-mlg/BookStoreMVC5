using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Domain.Entities;
using BookStore.Domain.Abstract;

namespace BookStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        public IBookRepository repository;
        public AdminController(IBookRepository repo) => repository = repo;
        public ViewResult Index() => View(repository.Books);
        public ViewResult Edit(int bookId)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
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
                repository.SaveBook(book);
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
            Book deletedBook = repository.DeleteBook(bookId);
            if (deletedBook != null)         
                TempData["message"] = string.Format("Книга \"{0}\" была удалена",
                    deletedBook.Title);            
            return RedirectToAction("Index");
        }
    }
}