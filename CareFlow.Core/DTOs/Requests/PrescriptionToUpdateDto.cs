using CareFlow.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.DTOs.Requests
{
    public class PrescriptionToUpdateDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public PrescriptionStatus Status { get; set; }
        [Required, MinLength(1)]
        public List<Guid> MedicinesIds { get; set; }


    }
}
