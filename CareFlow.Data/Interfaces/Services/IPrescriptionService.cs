using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IPrescriptionService
    {
        Task<PrescriptionToReturnDto> CreatePrescriptionAsync(PrescriptionToCreateDto dto, string userId);
        Task<PrescriptionToReturnDto> GetPrescriptionByIdAsync(Guid id, string userId);
        Task<IReadOnlyList<PrescriptionToReturnDto>> GetPatientPrescriptions(string userId);
        Task<IReadOnlyList<PrescriptionToReturnDto>> GetDoctorPrescriptions(string userId);
        Task<PrescriptionToReturnDto> UpdatePrescription(Guid id, PrescriptionToUpdateDto dto);
    }
}
