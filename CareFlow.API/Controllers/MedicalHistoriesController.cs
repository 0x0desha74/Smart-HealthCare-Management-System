using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CareFlow.API.Controllers
{

    public class MedicalHistoriesController : BaseApiController
    {
        private readonly IMedicalHistoryService _medicalHistory;

        public MedicalHistoriesController(IMedicalHistoryService medicalHistory)
        {
            _medicalHistory = medicalHistory;
        }


        [Authorize(Roles = "Doctor")]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MedicalHistoryToReturnDto>>> GetMedicalHistories()
        {
            var userId = User.FindFirstValue("uid");
            var medicalHistories = await _medicalHistory.GetMedicalHistoriesAsync(userId);
            return Ok(medicalHistories);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalHistoryToReturnDto>> GetMedicalHistory(Guid id)
        {
            var userId = User.FindFirstValue("uid");
            var medicalHistory = await _medicalHistory.GetMedicalHistoryAsync(id, userId);
            return Ok(medicalHistory);
        }
    }
}
