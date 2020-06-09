using System.Collections.Generic;
using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;

namespace BookStore.Domain.Concrete
{
    public class DbOrderProcessor : IOrderProcessorDb
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Purchase> Purchases => context.Purchases;
        public void ProcessOrderDB(Cart cart, DeliveryDetails deliveryDetails, User user)
        {
            foreach (var line in cart.Lines)
            {
                var purchase = new Purchase()
                {
                    BookId = line.Book.BookId,
                    Quantity = line.Quantity,
                    OrderId = deliveryDetails.OrderId,
                    UserId = user.UserId
                };
                context.Purchases.Add(purchase);
                var dbEntry = context.Books.Find(line.Book.BookId);
                if (dbEntry != null)
                    dbEntry.Quantity -= line.Quantity;
            }
            context.SaveChanges();
        }
    }
}
