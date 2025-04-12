using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IPhoneService
    {
        Task<IReadOnlyList<PhoneToReturnDto>> GetPhonesOfPatient(Guid patientId);
        Task<PhoneToReturnDto> GetPhoneOfPatient(Guid patientId, Guid id);
        Task<PhoneDto> CreatePhone(PhoneDto phoneDto, Guid patientId);
        Task<PhoneToReturnDto> UpdatePhone(Guid patientId, PhoneDto phoneDto);
        Task<bool> DeletePhone(Guid patientid, Guid id);
    }
}
