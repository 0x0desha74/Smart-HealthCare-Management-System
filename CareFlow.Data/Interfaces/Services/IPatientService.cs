using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Core.DTOs.Identity;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Specifications;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IPatientService
    {
        Task<Pagination<PatientToReturnDto>> GetPatientsAsync(SpecificationParameters specParams);
        Task<PatientToReturnDto> GetPatientAsync(Guid id);
        Task CreatePatientAsync(PatientRegisterDto patientDto, string userId);
        Task<PatientToReturnDto> UpdatePatientAsync(PatientDto patientDto);
        Task<bool> DeletePatientAsync(Guid id);
        Task<Pagination<AppointmentToReturnDto>> GetAppointmentsOfPatientAsync(SpecificationParameters specParams, string userId);
        Task<AppointmentDetailsDto> GetAppointmentOfPatientAsync(Guid appointmentId, string userId);
        Task<Pagination<AppointmentToReturnDto>> GetUpcomingAppointmentsOfPatientAsync(PaginationDto dto,string userId);
    }
}
