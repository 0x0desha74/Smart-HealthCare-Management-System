using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IMedicalHistoryService
    {
        Task<MedicalHistoryToReturnDto> CreateMedicalHistoryAsync(MedicalHistoryToCreateDto dto, string doctorUserId);
        Task<MedicalHistoryToReturnDto> GetMedicalHistoryAsync(Guid id, string userId);
        Task<IReadOnlyList<MedicalHistoryToReturnDto>> GetMedicalHistoriesAsync(string doctorUserId);
        Task<MedicalHistoryToReturnDto> UpdateMedicalHistoryAsync(Guid id, MedicalHistoryToUpdateDto dto);
    }
}
