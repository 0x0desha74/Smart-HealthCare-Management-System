using CareFlow.API.Errors;
using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CareFlow.API.Controllers
{

    public class AppointmentsController : BaseApiController
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }



        [Authorize(Roles = "Patient,Doctor")]
        [HttpGet]
        public async Task<ActionResult<Pagination<AppointmentToReturnDto>>> GetAppointments([FromQuery] AppointmentFilterDto specParams)
        {
            var appointments = await _appointmentService.GetAppointmentsAsync(specParams, User.FindFirstValue("uid"));
            if (appointments is null) return NotFound(new ApiResponse(404));
            return Ok(appointments);

        }



        [Authorize(Roles = "Patient,Doctor")]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDetailsDto>> GetAppointment(Guid id)
        {
            var appointment = await _appointmentService.GetAppointmentAsync(id, User.FindFirstValue("uid"));
            return Ok(appointment);
        }


        [Authorize(Roles = "Patient,Doctor")]
        [HttpPost]
        public async Task<ActionResult<AppointmentToReturnDto>> Create(AppointmentCreateDto model)
        {
            var appointment = await _appointmentService.CreateAppointmentAsync(model);
            return Ok(appointment);
        }

        [Authorize(Roles = "Patient,Doctor")]
        [HttpPut]
        public async Task<ActionResult<AppointmentToReturnDto>> Update(AppointmentUpdateDto model)
        {
            var appointment = await _appointmentService.UpdateAppointmentAsync(model, User.FindFirstValue("uid"));
            return Ok(appointment);
        }

        [Authorize(Roles = "Patient,Doctor")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await _appointmentService.DeleteAppointmentAsync(id, User.FindFirstValue("uid"));
            if (!isDeleted)
                return NotFound(new ApiResponse(404, "Appointment not found, Invalid appointment ID"));
            return NoContent();
        }

    }
}
