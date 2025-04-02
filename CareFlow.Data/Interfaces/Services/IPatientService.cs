using CareFlow.Core.DTOs.In;
using CareFlow.Core.DTOs.Response;
using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Interfaces.Services
{
   public interface IPatientService
    {
        Task<IReadOnlyList<PatientToReturnDto>> GetPatients();
        Task<PatientToReturnDto> GetPatient(Guid id);
        Task<PatientDto> CreatePatient(PatientDto patientDto);
        Task<PatientDto> UpdatePatient(PatientDto patientDto);
        Task<bool> DeletePatient(Guid id);
    }
}
