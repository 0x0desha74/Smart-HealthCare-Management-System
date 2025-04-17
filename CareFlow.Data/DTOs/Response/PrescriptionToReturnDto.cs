using CareFlow.Data.Entities.Enums;

namespace CareFlow.Core.DTOs.Response
{
    public class PrescriptionToReturnDto
    {
        public Guid Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Instruction { get; set; }
        public PrescriptionStatus Status { get; set; }
        public Guid PatientId { get; set; }
        public string Patient { get; set; }
        public Guid DoctorId { get; set; }
        public string Doctor { get; set; }
        public ICollection<MedicineToReturnDto> Medicines { get; set; }

    }
}
