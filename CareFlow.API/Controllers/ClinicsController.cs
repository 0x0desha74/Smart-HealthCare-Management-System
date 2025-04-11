using CareFlow.API.Errors;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareFlow.API.Controllers
{
 
    public class ClinicsController : BaseApiController
    {
        private readonly IClinicService _clinicService;

        public ClinicsController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ClinicDto>> Create(ClinicDto model)
        {
            var clinic = await _clinicService.CreateClinicAsync(model);
            return Ok(clinic);
        }
        
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ClinicToReturnDto>>> GetClinics()
        {
            var clinics = await _clinicService.GetClinics();
            if (clinics is null) return NotFound(new ApiResponse(404));
            return Ok(clinics);
        }

    }
}
