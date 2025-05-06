using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.DTOs.Identity
{
    public class RegisterDto
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(50)]
        public string Username { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
