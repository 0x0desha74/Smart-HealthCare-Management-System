using CareFlow.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Repository.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public async static Task SeedUser(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {

                var user = new AppUser()
                {
                    FullName = "Mustafa Elsayed",
                    Email = "mustafa.elsayed@gmail.com",
                    UserName = "mustafa.elsayed",
                    PhoneNumber = "0110110110",
                };
                await userManager.CreateAsync(user, "Pa$$word123");
            }
        }
    }
}
