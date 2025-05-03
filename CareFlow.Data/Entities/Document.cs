using CareFlow.Core.Entities;

namespace CareFlow.Data.Entities
{
    public class Document : BaseEntity
    {
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public Guid PatientId { get; set; }
        public DateTime UploadedAt { get; set; }
        public string UploadedByUserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Version { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Patient Patient { get; set; }
        public Guid MedicalHistoryId { get; set; }
        public MedicalHistory MedicalHistory{ get; set; }
    }
}
