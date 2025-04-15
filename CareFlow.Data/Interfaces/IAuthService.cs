using CareFlow.Core.DTOs.Identity;

namespace CareFlow.Core.Interfaces
{
    public interface IAuthService
    {
        Task<AuthDto> PatientRegisterAsync(PatientRegisterDto dto);
        Task<AuthDto> DoctorRegisterAsync(DoctorRegisterDto dto);
        Task<AuthDto> GetTokenAsync(GetTokenDto dto);
    }
}
