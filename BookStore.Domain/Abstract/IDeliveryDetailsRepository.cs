using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
