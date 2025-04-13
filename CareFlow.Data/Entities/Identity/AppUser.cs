using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LasrName { get; set; }
    }
}
