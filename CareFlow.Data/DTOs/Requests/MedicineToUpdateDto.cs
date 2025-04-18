﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.Requests
{
   public class MedicineToUpdateDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [Required,MaxLength(2500)]
        public string Description { get; set; }
        [Required,MaxLength(100)]
        public string Manufacture { get; set; }
        [Required,MaxLength(100)]
        public string Category { get; set; }
    }
}
