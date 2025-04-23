using CareFlow.API.Errors;
using CareFlow.Core.DTOs.In;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CareFlow.API.Controllers
{
    public class PatientsController : BaseApiController
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }


        //[Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PatientToReturnDto>>> GetPatients()
        {
            var patients = await _patientService.GetPatients();
            if (!patients.Any()) return NotFound(new ApiResponse(404));
            return Ok(patients);
        }

        //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientToReturnDto>> GetPatient(Guid id)
        {
            var patient = await _patientService.GetPatient(id);
            if (patient is null) return NotFound(new ApiResponse(404));
            return Ok(patient);
        }




        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<ActionDoneSuccessfullyDto>> Delete(Guid id)
        {
            var result = await _patientService.DeletePatientAsync(id);
            if (result is false) return BadRequest(new ApiResponse(400));
            return NoContent();
        }


        [HttpPut]
        public async Task<ActionResult<PatientToReturnDto>> Update(PatientDto model)
        {
            var updatedPatient = await _patientService.UpdatePatient(model);

            return Ok(updatedPatient);
        }


        [HttpGet("appointments")]
        public async Task<ActionResult<IReadOnlyList<AppointmentToReturnDto>>> GetAppointmentsOfPatient()
        {
            var userId = User.FindFirstValue("uid");
            var appointments = await _patientService.GetAppointmentsOfPatientAsync(userId);

            return !appointments.Any() ? Ok(appointments) : BadRequest(new ApiResponse(404));
        }

        [HttpGet("appointments/{id}")]
        public async Task<ActionResult<AppointmentDetailsDto>> GetAppointmentOfPatient(Guid id)
        {
            var userId = User.FindFirstValue("uid");
            var appointment = await _patientService.GetAppointmentOfPatient(id, userId);

            return appointment is not null ? Ok(appointment) : BadRequest(new ApiResponse(404));
        }

        [HttpGet("appointments/upcoming")]
        public async Task<ActionResult<AppointmentToReturnDto>> GetUpcomingPatientAppointments()
        {
            var userId = User.FindFirstValue("uid");
            var appointments = await _patientService.GetUpcomingAppointmentsOfPatientAsync(userId);
            if (!appointments.Any()) return NotFound(new ApiResponse(404, "No upcoming appointments"));
            return Ok(appointments);
        }

    }
}
