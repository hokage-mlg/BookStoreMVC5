using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Domain.Entities
{
    [Table("OrderLines")]
    public class Purchase
    {
        [Key]
        public int OrderLineId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
    }
}
