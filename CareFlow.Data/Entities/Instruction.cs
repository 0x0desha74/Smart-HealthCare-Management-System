using System.ComponentModel.DataAnnotations;

namespace CareFlow.Data.Entities
{
    public class Instruction : BaseEntity
    {
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(2500)]
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsComplete { get; set; }

        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }

        public Doctor Doctor { get; set; }
        public Guid? DoctorId { get; set; }
        public Guid MedicalHistoryId { get; set; }
    }
}
