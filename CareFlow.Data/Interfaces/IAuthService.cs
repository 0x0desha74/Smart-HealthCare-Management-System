using CareFlow.Core.DTOs.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Interfaces
{
    public interface IAuthService
    {
        Task<AuthDto> PatientRegisterAsync(PatientRegisterDto dto);
        Task<AuthDto> DoctorRegisterAsync(DoctorRegisterDto dto);
        Task<AuthDto> GetTokenAsync(GetTokenDto dto);
    }
}
