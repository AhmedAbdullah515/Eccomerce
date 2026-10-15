using System.ComponentModel.DataAnnotations;

namespace Eccomerce.DTOs
{
    public class CreateProductDTO
    {
        [Required]
        [StringLength(100), MinLength(2)]
        public string ProductName { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        [Range(0, 1000000)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 1000000)]
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
    }
}
