using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IClinicService
    {
        Task<Pagination<ClinicToReturnDto>> GetClinics(ClinicFilterDto dto);
        Task<ClinicToReturnDto> GetClinic(Guid id);
        Task<ClinicDto> CreateClinicAsync(ClinicDto clinicDto);
        Task<ClinicToReturnDto> UpdateClinicAsync(ClinicDto clinicDto);
        Task<bool> DeleteClinic(Guid id);
    }
}
