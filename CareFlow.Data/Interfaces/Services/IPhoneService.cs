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
        Task<IReadOnlyList<PhoneToReturnDto>> GetPhones();
        Task<PhoneToReturnDto> GetPhone(Guid id);
        Task<PhoneDto> CreatePhone(PhoneDto phoneDto,Guid patientId);
        Task<PhoneToReturnDto> UpdatePhone(PhoneDto phoneDto);
        Task<bool> DeletePhone(Guid id);
    }
}
