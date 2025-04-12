using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<IReadOnlyList<AppointmentToReturnDto>> GetAppointmentsAsync();
        Task<AppointmentDetailsDto> GetAppointmentAsync(Guid id);
        Task<AppointmentToReturnDto> CreateAppointmentAsync(AppointmentCreateDto appointmentDto);
        Task<AppointmentToReturnDto> UpdateAppointmentAsync(AppointmentUpdateDto appointmentDto);
    }
}
