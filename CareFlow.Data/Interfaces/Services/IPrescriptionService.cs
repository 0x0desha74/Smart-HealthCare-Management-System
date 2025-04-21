using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IPrescriptionService
    {
        Task<PrescriptionToReturnDto> CreatePrescriptionAsync(PrescriptionToCreateDto dto, string userId);
        Task<PrescriptionToReturnDto> GetPrescriptionAsync(Guid id,string userId);
    }
}
