using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var createdPrescription = await _prescriptionService.CreatePrescriptionAsync(model);
            return Ok(createdPrescription);
        }
    }
}
