using CareFlow.Core.Settings;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.DTOs.Requests
{
    public class DocumentToUploadDto
    {
        [Required]
        [MaxFileSize(10 * (1024 * 1024))] // 10 MB
        [AllowedFileExtensions(new[] { ".pdf", ".jpg", ".png" })]
        public IFormFile File { get; set; }
        [Required]
        public Guid PatientId { get; set; }
        [Required]
        public Guid MedicalHistoryId { get; set; }
    }
}
