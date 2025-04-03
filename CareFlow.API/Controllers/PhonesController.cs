using CareFlow.API.Errors;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
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

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PhoneToReturnDto>>> GetPhones(Guid patientId)
        {
            var phones = await _phoneService.GetPhonesOfPatient(patientId);
            if (phones is null) return NotFound(new ApiResponse(404, "No phones assigned for this user"));
            return Ok(phones);
        }


        [HttpGet("{phoneId}")]
        public async Task<ActionResult<PhoneToReturnDto>> GetPhoneOfPatient(Guid patientId, Guid phoneId)
        {
            var phone = await _phoneService.GetPhoneOfPatient(patientId, phoneId);
            if (phone is null) return NotFound(new ApiResponse(404));
            return Ok(phone);
        }



        [HttpPost]
        public async Task<ActionResult<PhoneDto>> Create(PhoneDto model,Guid patientId)
        {
            var phone = await _phoneService.CreatePhone(model, patientId);
            return Ok(phone);
        }


        [HttpPut]
        public async Task<ActionResult<PhoneToReturnDto>> Update(Guid patientId, PhoneDto model)
        {
            var phone = await _phoneService.UpdatePhone(patientId, model);
            return Ok(phone);

        }



        [HttpDelete("{phoneId}")]
        public async Task<IActionResult> Delete(Guid patientId,Guid phoneId)
        {
            var isDeleted = await _phoneService.DeletePhone(patientId, phoneId);
            if (isDeleted) return NoContent();
            return BadRequest(new ApiResponse(400, "An error occurred while deleting the phone number"));
        }

        

    }
}
