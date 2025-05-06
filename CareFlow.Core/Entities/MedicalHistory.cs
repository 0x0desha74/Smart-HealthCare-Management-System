using CareFlow.Core.Entities.Enums;
using CareFlow.Data.Entities;

namespace CareFlow.Core.Entities
{
    public class MedicalHistory : BaseEntity
    {
        public string Diagnosis { get; set; }
        public string TreatmentSummary { get; set; }
        public string ClinicalNotes { get; set; }
        public DateTime RecordDate { get; set; } = DateTime.UtcNow;
        public MedicalHistoryStatus Status { get; set; } = MedicalHistoryStatus.Active;
        public DateTime OnSetDate { get; set; }
        public bool RequiredFollowUp { get; set; }
        public DateTime FollowUpDate { get; set; }

        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }

        public Doctor Doctor { get; set; }
        public Guid DoctorId { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
        public ICollection<Document> Documents { get; set; } = new HashSet<Document>();



    }
}
