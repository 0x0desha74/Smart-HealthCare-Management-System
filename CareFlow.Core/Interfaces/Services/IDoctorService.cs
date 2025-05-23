﻿using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Core.DTOs.Identity;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IDoctorService
    {
        Task<Pagination<DoctorToReturnDto>> GetDoctorsAsync(DoctorFilterDto dto);
        Task<DoctorToReturnDto> GetDoctorAsync(Guid id);
        Task CreateDoctorAsync(DoctorRegisterDto doctorDto, string userId);
        Task<DoctorToReturnDto> UpdateDoctorAsync(DoctorDto doctorDto);
        Task<bool> DeleteDoctorAsync(Guid id);
        //Task<Pagination<AppointmentToReturnDto>> GetAppointmentsOfDoctor(SpecificationParameters specParams, string userId);
        Task<AppointmentToReturnDto> GetAppointmentOfDoctor(Guid appointmentId, string userId);
        Task<Pagination<AppointmentToReturnDto>> GetUpcomingAppointmentsOfDoctor(PaginationDto dto, string userId);
    }
}
