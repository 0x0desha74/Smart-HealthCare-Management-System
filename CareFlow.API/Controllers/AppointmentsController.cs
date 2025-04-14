using CareFlow.API.Errors;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareFlow.API.Controllers
{

    public class AppointmentsController : BaseApiController
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }



        //[Authorize(Roles = "Patient")]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppointmentToReturnDto>>> GetAppointments()
        {
            var appointments = await _appointmentService.GetAppointmentsAsync();
            if (appointments is null) return NotFound(new ApiResponse(404));
            return Ok(appointments);
            
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDetailsDto>> GetAppointment(Guid id)
        {
            var appointment = await _appointmentService.GetAppointmentAsync(id);
            return Ok(appointment);
        }


        //[Authorize(Roles = "Patient")]
        [HttpPost]
        public async Task<ActionResult<AppointmentToReturnDto>> Create(AppointmentCreateDto model)
        {
            var appointment = await _appointmentService.CreateAppointmentAsync(model);
            return Ok(appointment);
        }

        //[Authorize(Roles = "Patient")]
        [HttpPut]
        public async Task<ActionResult<AppointmentToReturnDto>> Update(AppointmentUpdateDto model)
        {
            var appointment = await _appointmentService.UpdateAppointmentAsync(model);
            return Ok(appointment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await _appointmentService.DeleteAppointmentAsync(id);
            if (!isDeleted)
                return NotFound(new ApiResponse(404,"Appointment not found, Invalid appointment ID"));
            return NoContent();
        }

    }
}
