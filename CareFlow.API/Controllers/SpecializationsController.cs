using CareFlow.API.Errors;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareFlow.API.Controllers
{

    public class SpecializationsController : BaseApiController
    {
        private readonly ISpecializationService _specializationService;

        public SpecializationsController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }



        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SpecializationDto>>> GetSpecializations()
        {
            var specializations = await _specializationService.GetSpecializationsAsync();
            if (specializations is null) return NotFound(new ApiResponse(404));
            return Ok(specializations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpecializationDto>> GetSpecialization(Guid id)
        {
            var specialization = await _specializationService.GetSpecializationAsync(id);
            if (specialization is null) return NotFound(new ApiResponse(404));
            return Ok(specialization);
        }



        //[Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(SpecializationDto model)
        {
            await _specializationService.AddSpecializationAsync(model);
            return Ok();
        }
    }
}
