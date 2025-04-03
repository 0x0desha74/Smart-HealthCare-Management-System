using CareFlow.Core.Entities.Identity;
using CareFlow.Repository.Identity;
using Microsoft.AspNetCore.Identity;

namespace CareFlow.API.Extensions
{
    public static class IdentityServicesExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {

            }).AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddAuthentication();

            return services;
        }
    }
}
