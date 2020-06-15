using System.Collections.Generic;
using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;

namespace BookStore.Domain.Concrete
{
    public class EFDeliveryDetailsRepository : IDeliveryDetailsRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<DeliveryDetails> DeliveryDetails => context.DeliveryDetails;
        public void SaveDeliveryDetails(DeliveryDetails deliveryDetails)
        {
            if (deliveryDetails.DeliveryDetailsId == 0)
                context.DeliveryDetails.Add(deliveryDetails);
            else
            {
                var dbEntry = context.DeliveryDetails.Find(deliveryDetails.DeliveryDetailsId);
                if (dbEntry != null)
                {
                    dbEntry.FullName = deliveryDetails.FullName;
                    dbEntry.Postcode = deliveryDetails.Postcode;
                    dbEntry.Country = deliveryDetails.Country;
                    dbEntry.City = deliveryDetails.City;
                    dbEntry.Street = deliveryDetails.Street;
                    dbEntry.Building = deliveryDetails.Building;
                    dbEntry.ApartmentNum = deliveryDetails.ApartmentNum;
                    dbEntry.GiftWrap = deliveryDetails.GiftWrap;
                }
            }
            context.SaveChanges();
        }
        public DeliveryDetails DeleteDeliveryDetails(int orderId)
        {
            var dbEntry = context.DeliveryDetails.Find(orderId);
            if (dbEntry != null)
            {
                context.DeliveryDetails.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
