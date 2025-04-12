using Microsoft.AspNetCore.Identity;

namespace CareFlow.Core.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
