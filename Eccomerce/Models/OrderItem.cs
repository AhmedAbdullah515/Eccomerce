using System.ComponentModel.DataAnnotations;

namespace Eccomerce.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }
        [Required]
        [Range(1, 1000000)]
        public decimal UnitPrice { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
