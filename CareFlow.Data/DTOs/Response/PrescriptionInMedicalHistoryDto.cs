using CareFlow.Data.Entities.Enums;

namespace CareFlow.Core.DTOs.Response
{
    public class PrescriptionInMedicalHistoryDto
    {
        public Guid Id { get; set; }
        public DateTime IssueDate { get; set; }
        public PrescriptionStatus Status { get; set; }
    }
}
