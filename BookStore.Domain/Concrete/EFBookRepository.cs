using System.Collections.Generic;
using BookStore.Domain.Entities;
using BookStore.Domain.Abstract;

namespace BookStore.Domain.Concrete
{
    public class EFBookRepository : IBookRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Book> Books => context.Books;
        public void SaveBook(Book book)
        {
            if (book.BookId == 0)
                context.Books.Add(book);
            else
            {
                var dbEntry = context.Books.Find(book.BookId);
                if (dbEntry != null)
                {
                    dbEntry.Title = book.Title;
                    dbEntry.Author = book.Author;
                    dbEntry.Description = book.Description;
                    dbEntry.Genre = book.Genre;
                    dbEntry.Price = book.Price;
                    dbEntry.Quantity = book.Quantity;
                    dbEntry.ImageData = book.ImageData;
                    dbEntry.ImageMimeType = book.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
        public Book DeleteBook(int bookId)
        {
            var dbEntry = context.Books.Find(bookId);
            if (dbEntry != null)
            {
                context.Books.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public void AddToCart(Book book, int quantity)
        {
            var dbEntry = context.Books.Find(book.BookId);
            if (dbEntry != null && dbEntry.Quantity>=0)
            {
                dbEntry.Quantity -= quantity;
            }
            context.SaveChanges();
        }
        public void RemoveFromCart(Book book, int quantity)
        {
            var dbEntry = context.Books.Find(book.BookId);
            if (dbEntry != null)
            {
                dbEntry.Quantity += quantity;
                context.SaveChanges();
            }
        }
    }
}
