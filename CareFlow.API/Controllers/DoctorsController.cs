using CareFlow.API.Errors;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
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
            var doctors = await _doctorService.GetDoctorsAsync();
            if (doctors is null) return NotFound(new ApiResponse(404));
            return Ok(doctors);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorToReturnDto>> GetDoctor(Guid id)
        {
            var doctor = await _doctorService.GetDoctorAsync(id);
            if (doctor is null) return NotFound(new ApiResponse(404, "Doctor not found"));
            return Ok(doctor);
        }


        //[Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<ActionResult<DoctorToReturnDto>> Create(DoctorDto model)
        {
            var doctor = await _doctorService.CreateDoctorAsync(model);
            return Ok(doctor);
        }


        //[Authorize(Roles ="Admin")]
        [HttpPut]
        public async Task<ActionResult<DoctorToReturnDto>> Update(DoctorDto model)
        {
            var doctor = await _doctorService.UpdateDoctorAsync(model);
            if (doctor is null) return NotFound(new ApiResponse(404, "Doctor Not Found, Id is invalid"));
            return Ok(doctor);
        }


        //[Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await _doctorService.DeleteDoctorAsync(id);
            if (!isDeleted) return NotFound(new ApiResponse(404, "Doctor not found, Invalid doctor Id"));
            return NoContent();
        }
    }
}
