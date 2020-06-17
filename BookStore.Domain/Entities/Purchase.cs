using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Domain.Entities
{
    [Table("Orders")]
    public class Purchase
    {
        [Key]
        [Display(Name = "ID")]
        public int OrderLineId { get; set; }
        [Display(Name = "КнигаID")]
        public int BookId { get; set; }
        [Display(Name = "Количество")]
        public int Quantity { get; set; }
        [Display(Name = "ДоставкаID")]
        public int DeliveryDetailsId { get; set; }
        [Display(Name = "ПользовательID")]
        public int UserId { get; set; }
        [Display(Name = "Статус доставки")]
        public string DeliveryStatus { get; set; }
    }
}
