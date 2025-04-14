using AutoMapper;
using CareFlow.Core.DTOs.Identity;
using CareFlow.Core.Entities.Identity;
using CareFlow.Core.Interfaces;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public AuthService(UserManager<AppUser> userManager, IMapper mapper, IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public async Task<AuthDto> RegisterAsync(RegisterDto dto)
        {
            if (await _userManager.FindByEmailAsync(dto.Email) is not null)
                return new AuthDto() { Message = "Email already exists" };

            if (await _userManager.FindByNameAsync(dto.Username) is not null)
                return new AuthDto() { Message = "Username already exists" };

            var user = new AppUser()
            {
                FirstName = dto.FirstName,
                LasrName = dto.LastName,
                Email = dto.Email,
                UserName = dto.Username
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description}";
                return new AuthDto() { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "Patient");

            var patient = _mapper.Map<Patient>(dto);
            patient.AppUserId = user.Id.ToString();
            await _unitOfWork.Repository<Patient>().AddAsync(patient);
            var patientCreationResult = await _unitOfWork.Complete();

            if (patientCreationResult <= 0)
                throw new InvalidOperationException("An error occurred while creating patient entity");

            var token = await _tokenService.CreateTokenAsync(user, _userManager);

            return new AuthDto()
            {
                Email = dto.Email,
                Username = dto.Username,
                IsAuthenticated = true,
                Roles = new List<string>() { "Patient" },
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresOn = token.ValidTo
            };

        }




        public async Task<AuthDto> GetTokenAsync(GetTokenDto dto)
        {
            var authDto = new AuthDto();

            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user is null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                return new AuthDto() { Message = "Invalid Email or Password" };


            var token = await _tokenService.CreateTokenAsync(user, _userManager);
            var rolesList = await _userManager.GetRolesAsync(user);
            authDto.IsAuthenticated = true;
            authDto.Email = user.Email;
            authDto.Username = user.UserName;
            authDto.Token = new JwtSecurityTokenHandler().WriteToken(token);
            authDto.ExpiresOn = token.ValidTo;
            authDto.Roles = rolesList.ToList();

            return authDto;
        }

    }
}
