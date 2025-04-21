using CareFlow.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.DTOs.Requests
{
    public class PrescriptionToCreateDto
    {

        [Required, MaxLength(1500)]
        public string Diagnosis { get; set; }
        [Required, MaxLength(1500)]
        public string TreatmentSummary { get; set; }
        [Required, MaxLength(1500)]
        public string ClinicalNotes { get; set; }
        [Required]
        public DateTime OnSetDate { get; set; }
        [Required]
        public bool RequiredFollowUp { get; set; }
        [Required]
        public DateTime FollowUpDate { get; set; }
        public PrescriptionStatus Status { get; set; } = PrescriptionStatus.Active;
        [Required]
        public Guid PatientId { get; set; }
        public List<Guid> MedicinesIds { get; set; }
        //public List<InstructionToCreateDto> Instructions { get; set; } = new();
        public Guid MedicalHistoryId { get; set; }

    }
}
