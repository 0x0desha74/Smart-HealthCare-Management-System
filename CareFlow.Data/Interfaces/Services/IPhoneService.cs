using CareFlow.Core.DTOs.In;
using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IPhoneService
    {
        Task<IReadOnlyList<PhoneToReturnDto>> GetPhonesOfPatient(Guid patientId);
        Task<PhoneToReturnDto> GetPhoneOfPatient(Guid patientId,Guid id);
        Task<PhoneDto> CreatePhone(PhoneDto phoneDto,Guid patientId);
        Task<PhoneToReturnDto> UpdatePhone(Guid patientId,PhoneDto phoneDto);
        Task<bool> DeletePhone(Guid patientid,Guid id);
    }
}
