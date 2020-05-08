using BookStore.Domain.Entities;

namespace BookStore.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, DeliveryDetails deliveryDetails);
    }
}
