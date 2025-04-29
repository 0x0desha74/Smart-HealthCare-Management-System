using CareFlow.Core.DTOs.Requests;
using CareFlow.Core.DTOs.Response;

namespace CareFlow.Core.Interfaces.Services
{
    public interface IDocumentService
    {
        Task UploadDocumentAsync(DocumentToUploadDto dto, string userId);
        Task<DocumentToReturnDto> GetDocumentAsync(Guid id, string userId);
        Task<(Byte[] fileDate, string contentType, string fileName)> DownloadDocumentAsync(Guid id, string userId);
        Task UpdateDocumentAsync(Guid id,DocumentToUpdateDto dto,string userId);
        Task<IReadOnlyList<DocumentToReturnDto>> GetDocumentsForPatientAsync(string userId);
    }
}
