using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;

namespace BookStore.WebUI.Models
{
    public class PurchasesListViewModel
    {
        public IUserRepository userRepository;
        public IOrderProcessorDb purchaseRepository;
        public IBookRepository bookRepository;
        public IDeliveryDetailsRepository deliveryDetailsRepository;
        public Book Book;
        public int Quantity;
        public DeliveryDetails DeliveryDetails;
        public User User;
        public PurchasesListViewModel(Book book, int quantity, DeliveryDetails deliveryDetails, User user)
        {
            Book = book;
            Quantity = quantity;
            DeliveryDetails = deliveryDetails;
            User = user;
        }
    }
}