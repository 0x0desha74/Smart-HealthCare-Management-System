using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IClinicService
    {
        Task<IReadOnlyList<ClinicToReturnDto>> GetClinics();
        Task<ClinicToReturnDto> GetClinic(Guid id);
        Task<ClinicDto> CreateClinicAsync(ClinicDto clinicDto);
    }
}
