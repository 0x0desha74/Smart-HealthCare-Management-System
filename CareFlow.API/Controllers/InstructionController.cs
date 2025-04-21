using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
using CareFlow.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CareFlow.API.Controllers
{
    [Route("api/prescriptions/{prescriptionId}/instructions")]
    [ApiController]
    public class InstructionController : ControllerBase
    {
        private readonly IInstructionService _instructionService;

        public InstructionController(IInstructionService instructionService)
        {
            _instructionService = instructionService;
        }


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Instruction>>> GetAllInstructionsForPrescription(Guid prescriptionId)
        {
            var userId = User.FindFirstValue("uid");
            var role = User.FindFirstValue(ClaimTypes.Role);
            var instructions = await _instructionService.GetInstructionsForPrescription(prescriptionId, userId);
            return Ok(instructions);
        }



        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public async Task<ActionResult<InstructionToReturnDto>> CreateAsync([FromBody] InstructionToCreateDto model, Guid prescriptionId)
        {
            var userId = User.FindFirstValue("uid");
            var instruction = await _instructionService.CreateInstructionAsync(model, prescriptionId, userId);
            return Ok(instruction);
        }
    }
}
