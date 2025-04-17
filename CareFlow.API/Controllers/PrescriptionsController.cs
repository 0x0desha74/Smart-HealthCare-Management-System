using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
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

        [HttpPost]
        public async Task<ActionResult<PrescriptionToReturnDto>> Create(PrescriptionToCreateDto model)
        {
            var userId = User.FindFirstValue("uid");
            var createdPrescription = await _prescriptionService.CreatePrescriptionAsync(model, userId);
            return Ok(createdPrescription);
        }
    }
}
