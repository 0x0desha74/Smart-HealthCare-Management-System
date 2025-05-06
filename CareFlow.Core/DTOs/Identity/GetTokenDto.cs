using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.DTOs.Identity
{
    public class GetTokenDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
