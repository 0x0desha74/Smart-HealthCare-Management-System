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
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public AuthService(UserManager<AppUser> userManager, IMapper mapper, ITokenService tokenService, IPatientService patientService, IDoctorService doctorService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
            _patientService = patientService;
            _doctorService = doctorService;
            _roleManager = roleManager;
        }



        public async Task<AuthDto> PatientRegisterAsync(PatientRegisterDto dto)
        {
            var registerDto = _mapper.Map<RegisterDto>(dto);
            var (user, errors) = await CreateUserAsync(registerDto, "Patient");

            if (user is null)
                return new AuthDto() { Message = errors };


            await _patientService.CreatePatientAsync(dto, user.Id);

            var token = await _tokenService.CreateTokenAsync(user, _userManager);

            return await GenerateAuthDtoAsync(user);

        }



        public async Task<AuthDto> DoctorRegisterAsync(DoctorRegisterDto dto)
        {
            var registerDto = _mapper.Map<RegisterDto>(dto);
            var (user, errors) = await CreateUserAsync(registerDto, "Doctor");

            if (user is null)
                return new AuthDto() { Message = errors };


            await _doctorService.CreateDoctorAsync(dto, user.Id);

            return await GenerateAuthDtoAsync(user);

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





        private async Task<(AppUser?, string?)> CreateUserAsync(RegisterDto dto, string role)
        {
            if (await _userManager.FindByEmailAsync(dto.Email) is not null)
                return (null, "Email already exists");

            if (await _userManager.FindByNameAsync(dto.Username) is not null)
                return (null, "Username already exists");

            var user = new AppUser()
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.Username,
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join("|", result.Errors.Select(e => e.Description));
                return (null, errors);
            }
            await _userManager.AddToRoleAsync(user, role);

            return (user, null);
        }

        private async Task<AuthDto> GenerateAuthDtoAsync(AppUser user)
        {
            var token = await _tokenService.CreateTokenAsync(user, _userManager);
            var roles = await _userManager.GetRolesAsync(user);
            return new AuthDto()
            {
                Email = user.Email,
                Username = user.UserName,
                IsAuthenticated = true,
                Roles = roles.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresOn = token.ValidTo
            };
        }

    }
}
