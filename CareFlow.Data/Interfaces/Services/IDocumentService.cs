using CareFlow.Core.DTOs.Requests;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IDocumentService
    {
        Task UploadDocumentAsync(DocumentToUploadDto dto, string userId);
    }
}
