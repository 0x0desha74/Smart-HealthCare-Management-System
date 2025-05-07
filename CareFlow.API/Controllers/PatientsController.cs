using CareFlow.API.Errors;
using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Core.Specifications;
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


        [Authorize(Roles = "Admin,Doctor")]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Pagination<PatientToReturnDto>>>> GetPatients([FromQuery] PatientFilterDto specParams)
        {
            var patients = await _patientService.GetPatientsAsync(specParams);
            if (!patients.Data.Any()) return NotFound(new ApiResponse(404));
            return Ok(patients);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientToReturnDto>> GetPatient(Guid id)
        {
            var patient = await _patientService.GetPatientAsync(id);
            if (patient is null) return NotFound(new ApiResponse(404));
            return Ok(patient);
        }




        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<ActionResult<ActionDoneSuccessfullyDto>> Delete(Guid id)
        {
            var result = await _patientService.DeletePatientAsync(id);
            if (result is false) return BadRequest(new ApiResponse(400));
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<PatientToReturnDto>> Update(PatientDto model)
        {
            var updatedPatient = await _patientService.UpdatePatientAsync(model);

            return Ok(updatedPatient);
        }


        [Authorize(Roles = "Patient")]
        [HttpGet("appointments")]
        public async Task<ActionResult<Pagination<AppointmentToReturnDto>>> GetAppointmentsOfPatient([FromQuery] SpecificationParameters specParams)
        {
            var userId = User.FindFirstValue("uid");
            var appointments = await _patientService.GetAppointmentsOfPatientAsync(specParams, userId);

            return appointments.Data.Any() ? Ok(appointments) : BadRequest(new ApiResponse(404));
        }

        [HttpGet("appointments/{id}")]
        public async Task<ActionResult<AppointmentDetailsDto>> GetAppointmentOfPatient(Guid id)
        {
            var userId = User.FindFirstValue("uid");
            var appointment = await _patientService.GetAppointmentOfPatientAsync(id, userId);

            return appointment is not null ? Ok(appointment) : BadRequest(new ApiResponse(404));
        }

        [Authorize(Roles = "Patient")]
        [HttpGet("appointments/upcoming")]
        public async Task<ActionResult<IReadOnlyList<Pagination<AppointmentToReturnDto>>>> GetUpcomingPatientAppointments([FromQuery] PaginationDto specParams)
        {
            var appointments = await _patientService.GetUpcomingAppointmentsOfPatientAsync(specParams, User.FindFirstValue("uid"));
            if (!appointments.Data.Any()) return NotFound(new ApiResponse(404, "No upcoming appointments"));
            return Ok(appointments);
        }

    }
}
