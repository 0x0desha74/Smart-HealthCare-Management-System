using CareFlow.API.Errors;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareFlow.API.Controllers
{
   
    public class DoctorsController : BaseApiController
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DoctorToReturnDto>>> GetDoctors()
        {
            var doctors = await _doctorService.GetDoctors();
            if (doctors is null) return NotFound(new ApiResponse(404));
            return Ok(doctors);
        }



        [HttpPost]
        public async Task<ActionResult<DoctorToReturnDto>> Create(DoctorDto model)
        {
            var doctor = await _doctorService.CreateDoctorAsync(model);
            return Ok(doctor);
        }
    }
}
