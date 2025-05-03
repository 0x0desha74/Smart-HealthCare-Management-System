using CareFlow.Core.DTOs.Identity;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Specifications;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IPatientService
    {
        Task<Pagination<PatientToReturnDto>> GetPatients(SpecificationParameters specParams);
        Task<PatientToReturnDto> GetPatient(Guid id);
        Task CreatePatientAsync(PatientRegisterDto patientDto, string userId);
        Task<PatientToReturnDto> UpdatePatient(PatientDto patientDto);
        Task<bool> DeletePatientAsync(Guid id);
        Task<IReadOnlyList<AppointmentToReturnDto>> GetAppointmentsOfPatientAsync(string userId);
        Task<AppointmentDetailsDto> GetAppointmentOfPatient(Guid appointmentId, string userId);
        Task<IReadOnlyList<AppointmentToReturnDto>> GetUpcomingAppointmentsOfPatientAsync(string userId);
    }
}
