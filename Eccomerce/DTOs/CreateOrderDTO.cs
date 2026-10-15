using System.ComponentModel.DataAnnotations;

namespace Eccomerce.DTOs
{
    public class CreateOrderDTO
    {
        public DateTime OrderDate { get; set; }
        [Required]
        public string Satus { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
    }
}
