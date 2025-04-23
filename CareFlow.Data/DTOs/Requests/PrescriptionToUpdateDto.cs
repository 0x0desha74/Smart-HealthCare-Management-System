using CareFlow.Core.Entities;
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
