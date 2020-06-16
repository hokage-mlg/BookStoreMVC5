using System.Collections.Generic;
using System.Linq;

namespace BookStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public IEnumerable<CartLine> Lines => lineCollection;
        public void AddItem(Book book, int quantity)
        {
            var line = lineCollection.Where(b => b.Book.BookId == book.BookId).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            else
                line.Quantity += quantity;
        }
        public decimal ComputeTotalValue() =>
        lineCollection.Sum(b => b.Book.Price * b.Quantity);
        public void RemoveLine(Book book) =>
        lineCollection.RemoveAll(b => b.Book.BookId == book.BookId);
        public void Clear() => lineCollection.Clear();
    }
    public class CartLine
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}