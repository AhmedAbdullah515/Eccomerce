using System.ComponentModel.DataAnnotations;

namespace Eccomerce.DTOs
{
    public class RegistrationDTO
    {
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
    }
}
