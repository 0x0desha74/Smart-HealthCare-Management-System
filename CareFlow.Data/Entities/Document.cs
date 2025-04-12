namespace CareFlow.Data.Entities
{
    public class Document : BaseEntity
    {
        public string Title { get; set; }
        public string FileUrl { get; set; }
        public string DocumentType { get; set; }
        public DateTime UpdateDate { get; set; }
        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }
        public Guid MedicalHistoryId { get; set; }
    }
}
