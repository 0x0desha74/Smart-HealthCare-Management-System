using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IMedicineService
    {
        Task<MedicineToReturnDto> CreateMedicineAsync(MedicineToCreateDto dto);
        Task<MedicineToReturnDto> UpdateMedicineAsync(MedicineToUpdateDto dto);
    }
}
