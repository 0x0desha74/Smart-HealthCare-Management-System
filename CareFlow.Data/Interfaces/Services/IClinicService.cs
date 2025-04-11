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
        Task<ClinicDto> CreateClinicAsync(ClinicDto clinicDto);
        Task<IReadOnlyList<ClinicToReturnDto>> GetClinics();
    }
}
