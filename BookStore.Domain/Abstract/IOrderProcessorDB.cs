using BookStore.Domain.Entities;
using System.Collections.Generic;

namespace BookStore.Domain.Abstract
{
    public interface IOrderProcessorDb
    {
        IEnumerable<Purchase> Purchases { get; }
        void ProcessOrderDB(Cart cart, DeliveryDetails deliveryDetails, User user);
        void ChangeDeliveryStatus(int orderLineId, string status);
        void DeletePurchase(int orderLineId);
    }
}
