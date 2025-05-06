using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IAllergyService
    {
        Task<IReadOnlyList<AllergyToReturnDto>> GetAllergiesForPatient(Guid patientId);
        Task<AllergyDto> AddAllergyToPatient(Guid patientId, AllergyDto allergyDto);
        Task<bool> DeleteAllergyFromPatient(Guid patientId, Guid allergyId);
    }
}
