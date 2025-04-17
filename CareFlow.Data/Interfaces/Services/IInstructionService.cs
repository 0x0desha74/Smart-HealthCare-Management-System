using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Interfaces.Services
{
   public interface IInstructionService
    {
        Task<InstructionToReturnDto> CreateInstructionAsync(InstructionToCreateDto dto,Guid prescriptionId,string userId);
    }
}
