using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Domain.Entities
{
    [Table("Orders")]
    public class Purchase
    {
        [Key]
        public int OrderLineId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public int DeliveryDetailsId { get; set; }
        public int UserId { get; set; }
        public string DeliveryStatus { get; set; }
    }
}
