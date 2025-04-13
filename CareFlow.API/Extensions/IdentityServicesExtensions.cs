using CareFlow.API.Helper;
using CareFlow.Core.Entities.Identity;
using CareFlow.Repository.Data.Identity;
using Microsoft.AspNetCore.Identity;

namespace CareFlow.API.Extensions
{
    public static class IdentityServicesExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.Configure<JWT>(configuration.GetSection("JWT"));

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {

            }).AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddAuthentication();

            return services;
        }
    }
}
