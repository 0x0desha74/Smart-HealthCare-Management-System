﻿using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<Pagination<AppointmentToReturnDto>> GetAppointmentsAsync(AppointmentFilterDto specParams, string userId);
        Task<AppointmentDetailsDto> GetAppointmentAsync(Guid id, string userId);
        Task<AppointmentToReturnDto> CreateAppointmentAsync(AppointmentCreateDto appointmentDto);
        Task<AppointmentToReturnDto> UpdateAppointmentAsync(AppointmentUpdateDto appointmentDto, string userId);
        Task<bool> DeleteAppointmentAsync(Guid id, string userId);
    }
}
