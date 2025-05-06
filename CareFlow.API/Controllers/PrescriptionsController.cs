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

    public class PrescriptionsController : BaseApiController
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<PrescriptionToReturnDto>> GetByIdAsync(Guid id)
        {
            var userId = User.FindFirstValue("uid");
            var prescription = await _prescriptionService.GetPrescriptionByIdAsync(id, userId);
            if (prescription is null) return Unauthorized(new ApiResponse(401));
            return Ok(prescription);
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet("doctor")]
        public async Task<ActionResult<IReadOnlyList<Pagination<PrescriptionToReturnDto>>>> GetDoctorPrescriptions([FromQuery] PrescriptionFilterDto specParams)
        {
            var userId = User.FindFirstValue("uid");
            var prescriptions = await _prescriptionService.GetDoctorPrescriptionsAsync(specParams,userId);
            return Ok(prescriptions);
        }

        [Authorize(Roles = "Patient")]
        [HttpGet("patient")]
        public async Task<ActionResult<IReadOnlyList<Pagination<PrescriptionToReturnDto>>>> GetPatientPrescriptions([FromQuery] PrescriptionFilterDto specParams)
        {
            var userId = User.FindFirstValue("uid");
            var prescriptions = await _prescriptionService.GetPatientPrescriptionsAsync(specParams,userId);
            return Ok(prescriptions);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public async Task<ActionResult<PrescriptionToReturnDto>> Create(PrescriptionToCreateDto model)
        {
            var userId = User.FindFirstValue("uid");
            var createdPrescription = await _prescriptionService.CreatePrescriptionAsync(model, userId);
            return Ok(createdPrescription);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPut("{id}")]
        public async Task<ActionResult<PrescriptionToReturnDto>> Update(Guid id, PrescriptionToUpdateDto model)
        {
            var userId = User.FindFirstValue("uid");
            var UpdatedPrescription = await _prescriptionService.UpdatePrescriptionAsync(id, model, userId);
            return Ok(UpdatedPrescription);
        }


        [Authorize(Roles = "Doctor")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrescriptionToReturnDto>> Delete(Guid id)
        {
            var userId = User.FindFirstValue("uid");
            await _prescriptionService.DeletePrescriptionAsync(id, userId);

            return NoContent();
        }

        [Authorize(Roles = "Doctor")]
        [HttpPatch("{id}/status")]
        public async Task<ActionResult<PrescriptionToReturnDto>> UpdateStatus(Guid id, PrescriptionStatusToUpdateDto model)
        {
            var userId = User.FindFirstValue("uid");
            return Ok(await _prescriptionService.UpdatePrescriptionStatusAsync(id, model, userId));
        }





    }
}
