using CareFlow.Core.DTOs.Identity;
using CareFlow.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CareFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }



        [HttpPost("register/patient")]
        public async Task<ActionResult<AuthDto>> RegisterAsync(PatientRegisterDto model)
        {
            var result = await _authService.PatientRegisterAsync(model);
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            return Ok(result);
        }


        [HttpPost("register/doctor")]
        public async Task<ActionResult<AuthDto>> RegisterAsync(DoctorRegisterDto model)
        {
            var result = await _authService.DoctorRegisterAsync(model);
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            return Ok(result);
        }


        [HttpPost("token")]
        public async Task<ActionResult<AuthDto>> GetTokenAsync(GetTokenDto model)
        {
            var result = await _authService.GetTokenAsync(model);
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
