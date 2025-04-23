using CareFlow.Core.Entities.Enums;

namespace CareFlow.Core.DTOs.Response
{
    public class MedicalHistoryToReturnDto
    {
        public Guid Id { get; set; }
        public string Diagnosis { get; set; }
        public string TreatmentSummary { get; set; }
        public string ClinicalNotes { get; set; }
        public DateTime RecordDate { get; set; }
        public MedicalHistoryStatus Status { get; set; }
        public DateTime OnSetDate { get; set; }
        public bool RequiredFollowUp { get; set; }
        public DateTime FollowUpDate { get; set; }

        public string Patient { get; set; }

        public string Doctor { get; set; }

        public ICollection<PrescriptionInMedicalHistoryDto> Prescriptions { get; set; }
        //public ICollection<Document> Documents { get; set; } = new HashSet<Document>();

    }
}
