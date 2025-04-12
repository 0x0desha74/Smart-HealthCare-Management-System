using CareFlow.Core.DTOs.In;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IPatientService
    {
        Task<IReadOnlyList<PatientToReturnDto>> GetPatients();
        Task<PatientToReturnDto> GetPatient(Guid id);
        Task<PatientDto> CreatePatient(PatientDto patientDto);
        Task<PatientToReturnDto> UpdatePatient(PatientDto patientDto);
        Task<bool> DeletePatient(Guid id);
    }
}
