using CareFlow.Core.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Interfaces.Services
{
   public interface IAllergyService
    {
        Task<AllergyDto> AddAllergyToPatient(Guid patientId,AllergyDto allergyDto);
    }
}
