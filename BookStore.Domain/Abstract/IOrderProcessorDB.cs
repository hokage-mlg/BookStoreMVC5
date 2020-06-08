using BookStore.Domain.Entities;

namespace BookStore.Domain.Abstract
{
    public interface IOrderProcessorDb
    {
        void ProcessOrderDB(Cart cart, DeliveryDetails deliveryDetails, User user);
    }
}
