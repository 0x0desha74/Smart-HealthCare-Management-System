using CareFlow.Data.Entities.Enums;

namespace CareFlow.Data.Entities
{
    public class Prescription : BaseEntity
    {
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Instruction { get; set; }
        public PrescriptionStatus Status { get; set; }

        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }

        public Doctor Doctor { get; set; }
        public Guid? DoctorId { get; set; }

        public ICollection<Medicine> Medicines { get; set; }

        public Guid MedicalHistoryId { get; set; }
    }
}
