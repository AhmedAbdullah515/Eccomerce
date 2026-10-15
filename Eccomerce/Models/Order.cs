using System.ComponentModel.DataAnnotations;

namespace Eccomerce.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Satus { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public User ?User { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
