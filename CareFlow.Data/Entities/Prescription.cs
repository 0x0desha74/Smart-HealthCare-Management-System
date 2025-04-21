using CareFlow.Core.Entities;
using CareFlow.Data.Entities.Enums;

namespace CareFlow.Data.Entities
{
    public class Prescription : BaseEntity
    {
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
        public DateTime ExpiryDate => IssueDate.AddMonths(6);
        public PrescriptionStatus Status { get; set; }

        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }

        public Doctor Doctor { get; set; }
        public Guid? DoctorId { get; set; }

        public ICollection<Medicine> Medicines { get; set; }
        public ICollection<Instruction> Instructions { get; set; } = new HashSet<Instruction>();
        public MedicalHistory MedicalHistory { get; set; }
        public Guid MedicalHistoryId { get; set; }
        public Guid? AppointmentId { get; set; }
    }
}
