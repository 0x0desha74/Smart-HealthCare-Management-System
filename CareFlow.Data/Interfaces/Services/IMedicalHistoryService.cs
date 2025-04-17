using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Interfaces.Services
{
   public interface IMedicalHistoryService
    {
        Task<MedicalHistory> CreateMedicalHistoryAsync(MedicalHistoryToCreateDto dto,Guid doctorId);
    }
}
