using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IDocumentService
    {
        Task UploadDocumentAsync(DocumentToUploadDto dto, string userId);
        Task<DocumentToReturnDto> GetDocumentAsync(Guid id, string userId);
    }
}
