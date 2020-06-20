using System.Collections.Generic;
using BookStore.Domain.Entities;

namespace BookStore.Domain.Abstract
{
    public interface IDeliveryDetailsRepository
    {
        IEnumerable<DeliveryDetails> DeliveryDetails { get; }
        void SaveDeliveryDetails(DeliveryDetails deliveryDetails);
        DeliveryDetails DeleteDeliveryDetails(int orderId);
    }
}
