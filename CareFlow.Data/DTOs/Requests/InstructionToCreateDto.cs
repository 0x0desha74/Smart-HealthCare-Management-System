using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.Requests
{
   public class InstructionToCreateDto
    {
        [Required,MaxLength(100)]
        public string Title { get; set; }
        [Required,MaxLength(2500)]
        public string Description { get; set; }
    }
}
