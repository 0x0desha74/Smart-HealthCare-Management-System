using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IPrescriptionService
    {
        Task<PrescriptionToReturnDto> CreatePrescriptionAsync(PrescriptionToCreateDto dto, string userId);
        Task<PrescriptionToReturnDto> GetPrescriptionByIdAsync(Guid id, string userId);
        Task<IReadOnlyList<PrescriptionToReturnDto>> GetPatientPrescriptionsAsync(string userId);
        Task<IReadOnlyList<PrescriptionToReturnDto>> GetDoctorPrescriptionsAsync(string userId);
        Task<PrescriptionToReturnDto> UpdatePrescriptionAsync(Guid id, PrescriptionToUpdateDto dto, string userId);
        Task DeletePrescriptionAsync(Guid id, string userId);
        Task<PrescriptionToReturnDto> UpdatePrescriptionStatusAsync(Guid id, PrescriptionStatusToUpdateDto dto, string userId);
    }
}
