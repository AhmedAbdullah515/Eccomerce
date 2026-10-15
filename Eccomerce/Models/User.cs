using System.ComponentModel.DataAnnotations;

namespace Eccomerce.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(100), MinLength(3)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
