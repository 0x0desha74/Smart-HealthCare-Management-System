using CareFlow.API.Errors;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareFlow.API.Controllers
{
    [Route("api/patients/{patientId}/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly IAllergyService _allergyService;

        public AllergiesController(IAllergyService allergyService)
        {
            _allergyService = allergyService;
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AllergyToReturnDto>>> GetAllergiesForPatient(Guid patientId)
        {
            var allergies = await _allergyService.GetAllergiesForPatient(patientId);
            if (allergies is null) return NotFound(new ApiResponse(404, "No allergies assigned for this patient"));
            return Ok(allergies);
        }







        [HttpPost]
        public async Task<ActionResult<AllergyDto>> Create(Guid patientId,AllergyDto model)
        {
            var allergy = await _allergyService.AddAllergyToPatient(patientId, model);
            return Ok(allergy);
        }





        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid patientId,Guid id)
        {
           var isDeleted =  await _allergyService.DeleteAllergyFromPatient(patientId, id);
            if(isDeleted) return NoContent();
            return BadRequest(new ApiResponse(400, "An error occurred while deleting the entity"));
        }
    }

}
