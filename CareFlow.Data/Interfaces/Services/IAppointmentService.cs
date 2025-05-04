using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using CareFlow.Core.Specifications;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<Pagination<AppointmentToReturnDto>> GetAppointmentsAsync(SpecificationParameters specParams);
        Task<AppointmentDetailsDto> GetAppointmentAsync(Guid id);
        Task<AppointmentToReturnDto> CreateAppointmentAsync(AppointmentCreateDto appointmentDto);
        Task<AppointmentToReturnDto> UpdateAppointmentAsync(AppointmentUpdateDto appointmentDto);
        Task<bool> DeleteAppointmentAsync(Guid id);
    }
}
