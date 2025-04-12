using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
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


        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDetailsDto>> GetAppointment(Guid id)
        {
            var appointment = await _appointmentService.GetAppointmentAsync(id);
            return Ok(appointment);
        }


        //[Authorize(Roles = "Patient")]
        [HttpPost]
        public async Task<ActionResult<AppointmentToReturnDto>> Create(AppointmentDto model)
        {
            var appointment = await _appointmentService.CreateAppointmentAsync(model);
            return Ok(appointment);
        }


    }
}
