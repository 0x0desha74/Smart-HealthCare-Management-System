using CareFlow.Data.Entities.Enums;
using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.DTOs.Requests
{
   public class PrescriptionToCreateDto
    {
        
        [Required,MaxLength(1500)]
        public string Instruction { get; set; }
        [Required,MaxLength(1500)]
        public string Diagnosis { get; set; }
        [Required,MaxLength(1500)]
        public string TreatmentSummary { get; set; }
        [Required,MaxLength(1500)]
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
        [Required]
        public Guid DoctorId { get; set; }
        public List<Guid> MedicinesIds { get; set; }
        [Required]
        public Guid MedicalHistoryId { get; set; }

    }
}
