using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.Entities;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IMedicalHistoryService
    {
        Task<MedicalHistory> CreateMedicalHistoryAsync(MedicalHistoryToCreateDto dto, Guid doctorId);
    }
}
