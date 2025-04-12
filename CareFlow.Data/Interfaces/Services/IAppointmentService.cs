using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<AppointmentToReturnDto> CreateAppointmentAsync(AppointmentDto appointmentDto);
    }
}
