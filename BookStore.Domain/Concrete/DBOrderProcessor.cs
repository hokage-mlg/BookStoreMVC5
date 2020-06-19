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
                    DeliveryDetailsId = deliveryDetails.DeliveryDetailsId,
                    UserId = user.UserId,
                    DeliveryStatus = "Отправлен"
                };
                context.Purchases.Add(purchase);
            }
            context.SaveChanges();
        }
        public void ChangeDeliveryStatus(int orderLineId, string status)
        {
            var dbEntry = context.Purchases.Find(orderLineId);
            if (dbEntry != null)
            {
                dbEntry.DeliveryStatus = status;
                context.SaveChanges();
            }
        }
        public void DeletePurchase(int orderLineId)
        {
            var dbEntry = context.Purchases.Find(orderLineId);
            if (dbEntry != null)
            {
                context.Purchases.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
