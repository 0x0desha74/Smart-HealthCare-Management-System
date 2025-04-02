using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareFlow.API.Controllers
{
    [Route("api/patients/{patientId}/[Controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly IPhoneService _phoneService;

        public PhonesController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [HttpPost]
        public async Task<ActionResult<PhoneDto>> Create(PhoneDto model,Guid patientId)
        {
            var phone = await _phoneService.CreatePhone(model, patientId);
            return Ok(phone);
        }
    }
}
