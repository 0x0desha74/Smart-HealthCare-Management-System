using CareFlow.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;


namespace CareFlow.Core.Interfaces.Services
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateTokenAsync(AppUser user,UserManager<AppUser> userManager);
    }
}
