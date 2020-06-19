using System.Collections.Generic;
using BookStore.Domain.Entities;

namespace BookStore.Domain.Abstract
{
    public interface IBookRepository
    {
        IEnumerable<Book> Books { get; }
        void SaveBook(Book book);
        Book DeleteBook(int bookId);
        void AddToCart(Book book, int quantity);
        void RemoveFromCart(Book book, int quantity);
    }
}
