using System.ComponentModel.DataAnnotations;

namespace Eccomerce.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [StringLength(100), MinLength(2)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string ?Description { get; set; }
        public List<Product> Products { get; set; }= new List<Product>();
    }
}
