using CareFlow.Core.Entities;
using CareFlow.Core.Interfaces;

namespace CareFlow.Data.Entities
{
    public class Document : BaseEntity, ISoftDeletable
    {
        public string StoredFileName { get; set; }
        public string OriginalFileName { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public Guid PatientId { get; set; }
        public DateTime UploadedAt { get; set; }
        public string UploadedByUserId { get; set; }
        public bool IsActive { get; set; }
        public string Version { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Patient Patient { get; set; }
        public Guid MedicalHistoryId { get; set; }
        public MedicalHistory MedicalHistory { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
