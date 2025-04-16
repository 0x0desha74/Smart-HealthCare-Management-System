using CareFlow.Core.DTOs.Identity;
using CareFlow.Core.DTOs.In;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IPatientService
    {
        Task<IReadOnlyList<PatientToReturnDto>> GetPatients();
        Task<PatientToReturnDto> GetPatient(Guid id);
        Task CreatePatientAsync(PatientRegisterDto patientDto, string userId);
        Task<PatientToReturnDto> UpdatePatient(PatientDto patientDto);
        Task<bool> DeletePatient(Guid id);
        Task<IReadOnlyList<AppointmentToReturnDto>> GetAppointmentsOfPatientAsync(string userId);
        Task<AppointmentDetailsDto> GetAppointmentOfPatient(Guid appointmentId,string userId);
        Task<IReadOnlyList<AppointmentToReturnDto>> GetUpcomingAppointmentsOfPatientAsync(string userId);
    }
}
