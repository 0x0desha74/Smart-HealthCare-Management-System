﻿using CareFlow.API.Errors;
using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CareFlow.API.Controllers
{

    public class DoctorsController : BaseApiController
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DoctorToReturnDto>>> GetDoctors([FromQuery] DoctorFilterDto specParams)
        {
            var doctors = await _doctorService.GetDoctorsAsync(specParams);
            if (!doctors.Data.Any()) return NotFound(new ApiResponse(404));
            return Ok(doctors);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorToReturnDto>> GetDoctor(Guid id)
        {
            var doctor = await _doctorService.GetDoctorAsync(id);
            if (doctor is null) return NotFound(new ApiResponse(404, "Doctor not found"));
            return Ok(doctor);
        }


        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<DoctorToReturnDto>> Update(DoctorDto model)
        {
            var doctor = await _doctorService.UpdateDoctorAsync(model);
            if (doctor is null) return NotFound(new ApiResponse(404, "Doctor Not Found, Id is invalid"));
            return Ok(doctor);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await _doctorService.DeleteDoctorAsync(id);
            if (!isDeleted) return NotFound(new ApiResponse(404, "Doctor not found, Invalid doctor Id"));
            return NoContent();
        }


        //[HttpGet("appointments")]
        //public async Task<ActionResult<Pagination<AppointmentToReturnDto>>> GetAppointmentsOfDoctor([FromQuery] SpecificationParameters specParams)
        //{
        //    var userId = User.FindFirstValue("uid");
        //    var appointments = await _doctorService.GetAppointmentsOfDoctor(specParams, userId);

        //    if (!appointments.Data.Any()) return NotFound(new ApiResponse(404));
        //    return Ok(appointments);
        //}

        [Authorize(Roles = "Doctor")]
        [HttpGet("appointments/{id}")]
        public async Task<ActionResult<AppointmentToReturnDto>> GetAppointmentOfDoctor(Guid id)
        {
            var userId = User.FindFirstValue("uid");
            var appointment = await _doctorService.GetAppointmentOfDoctor(id, userId);

            if (appointment is null)
                return NotFound(new ApiResponse(404));
            return Ok(appointment);
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet("appointments/upcoming")]
        public async Task<ActionResult<IReadOnlyList<AppointmentToReturnDto>>> GetUpcomingAppointments([FromQuery] PaginationDto specParams)
        {
            var userId = User.FindFirstValue("uid");
            var appointments = await _doctorService.GetUpcomingAppointmentsOfDoctor(specParams, userId);

            if (!appointments.Data.Any()) return NotFound(new ApiResponse(404, "No upcoming appointments"));
            return Ok(appointments);

        }
    }
}
