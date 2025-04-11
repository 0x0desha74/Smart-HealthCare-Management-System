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

        //[Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(SpecializationDto model)
        {
            await _specializationService.AddSpecializationAsync(model);
            return Ok();
        }
    }
}
