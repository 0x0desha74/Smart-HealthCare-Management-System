namespace CareFlow.Core.DTOs.Requests
{
    public class MedicalHistoryToCreateDto
    {
        public string Diagnosis { get; set; }
        public string TreatmentSummary { get; set; }
        public string ClinicalNotes { get; set; }
        public DateTime OnSetDate { get; set; }
        public bool RequiredFollowUp { get; set; }
        public DateTime FollowUpDate { get; set; }
        public Guid PatientId { get; set; }
        //public Guid DoctorId { get; set; }
    }
}
