using CareFlow.API.Errors;
using CareFlow.Core.DTOs.In;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CareFlow.API.Controllers
{
    public class PatientsController : BaseApiController
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }



        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PatientToReturnDto>>> GetPatients()
        {
            var patients = await _patientService.GetPatients();
            if (patients is null) return NotFound(new ApiResponse(404));
            return Ok(patients);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PatientToReturnDto>> GetPatient(Guid id)
        {
            var patient = await _patientService.GetPatient(id);
            if (patient is null) return NotFound(new ApiResponse(404));
            return Ok(patient);
        }


        [HttpPost]
        public async Task<ActionResult<PatientDto>> Create([FromBody] PatientDto model)
        {
            var patient = await _patientService.CreatePatient(model);
            if (patient is null) return BadRequest(new ApiResponse(400));
            return Ok(patient);
        }

        [HttpDelete]
        public async Task<ActionResult<ActionDoneSuccessfullyDto>> Delete(Guid id)
        {
           var result =  await _patientService.DeletePatient(id);
            if (result is false) return BadRequest(new ApiResponse(400));
            return Ok(new ActionDoneSuccessfullyDto("Patient was deleted successfully"));
        }
        
    }
}
