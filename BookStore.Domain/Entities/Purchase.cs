using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Domain.Entities
{
    [Table("OrderLines")]
    public class Purchase
    {
        [Key]
        public int OrderLineId { get; set; }
        public int Book_BookId { get; set; }
        public int Quantity { get; set; }
        public int DeliveryDetails_OrderId { get; set; }
    }
}
