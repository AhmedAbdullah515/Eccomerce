using System.ComponentModel.DataAnnotations;

namespace Eccomerce.DTOs
{
    public class CreateCategoryDTO
    {
        [Required]
        [StringLength(100), MinLength(2)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
