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



        public async static Task SeedRoles(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            List<string> roles = new List<string>()
            {
                "Admin",
                "Patient",
                "Doctor"
            };
            foreach(var role in roles)
            {
                if(!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var adminUser = await userManager.FindByEmailAsync("mustafa.elsayed@gmail.com");
            await userManager.AddToRoleAsync(adminUser, "Admin");





        }
    }
}
