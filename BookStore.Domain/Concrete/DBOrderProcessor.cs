using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //TODO ДОБАВЛЯЕТ ТОЛЬКО ПОСЛЕДНИЙ ID ПОТОМУ ЧТО Я ДАУН! ИСПРАВИТЬ КЛАСС PURCHASE!
            //что то типа модицифированной корзины + idUser+idDeliveryInfo
            foreach (var line  in cart.Lines)
            {
                Purchase purchase = new Purchase()
                {
                    BookId = line.Book.BookId,
                    Quantity = line.Quantity,
                    OrderId = deliveryDetails.OrderId,
                    UserId = user.UserId
                };
                context.Purchases.Add(purchase);
            }
            context.SaveChanges();
        }
    }
}
