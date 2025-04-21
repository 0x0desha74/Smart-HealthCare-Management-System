using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IInstructionService
    {
        Task<InstructionToReturnDto> CreateInstructionAsync(InstructionToCreateDto dto, Guid prescriptionId, string userId);
        Task<IReadOnlyList<InstructionToReturnDto>> GetInstructionsForPrescription(Guid prescriptionId, string userId);
        Task<InstructionToReturnDto> GetInstructionForPrescription(Guid prescriptionId,Guid instructionId, string userId);

    }
}
