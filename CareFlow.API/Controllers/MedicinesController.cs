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

        [HttpPost]
        public async Task<ActionResult<MedicineToReturnDto>> CreateAsync(MedicineToCreateDto model)
        {
            var medicine = await _medicineService.CreateMedicineAsync(model);
            return Ok(medicine);
        }
    }
}
