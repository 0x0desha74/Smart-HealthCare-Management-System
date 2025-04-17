using CareFlow.API.Errors;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareFlow.API.Controllers
{
   
    public class MedicinesController : BaseApiController
    {
        private readonly IMedicineService _medicineService;

        public MedicinesController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MedicineToReturnDto>>> GetAllAsync()
        {
            var medicines = await _medicineService.GetMedicinesAsync();
            if (medicines is null)
                return NotFound(new ApiResponse(404));
            return Ok(medicines);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicineToReturnDto>> GetByIdAsync(Guid id)
        {
            var medicine = await _medicineService.GetMedicineAsync(id);
            if (medicine is null)
                return NotFound(new ApiResponse(404));
            return Ok(medicine);
        }


        [HttpPost]
        public async Task<ActionResult<MedicineToReturnDto>> CreateAsync(MedicineToCreateDto model)
        {
            var createdMedicine = await _medicineService.CreateMedicineAsync(model);
            return Ok(createdMedicine);
        }

        [HttpPut]
        public async Task<ActionResult<MedicineToReturnDto>> UpdateAsync(MedicineToUpdateDto model)
        {
            var updatedMedicine = await _medicineService.UpdateMedicineAsync(model);
            return Ok(updatedMedicine);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var isDeleted = await _medicineService.DeleteMedicineAsync(id);
            if (!isDeleted)
                return NotFound(new ApiResponse(404));
            return NoContent();

        }
    }
}
