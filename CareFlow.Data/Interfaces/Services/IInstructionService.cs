using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IInstructionService
    {
        Task<InstructionToReturnDto> CreateInstructionAsync(InstructionToCreateDto dto, Guid prescriptionId, string userId);
        Task<IReadOnlyList<InstructionToReturnDto>> GetInstructionsAsync(Guid prescriptionId, string userId);
        Task<InstructionToReturnDto> GetInstructionForAsync(Guid prescriptionId, Guid instructionId, string userId);
        Task<InstructionToReturnDto> UpdateInstructionAsync( Guid prescriptionId, Guid instructionId, string userId, InstructionToUpdateDto dto);
        Task<bool> DeleteInstructionAsync(Guid prescriptionId, Guid instructionId, string userId);
    }
}
