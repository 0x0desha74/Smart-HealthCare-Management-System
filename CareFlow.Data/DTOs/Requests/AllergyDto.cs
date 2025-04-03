using CareFlow.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.Requests
{
    public class AllergyDto
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        [Required]
        public AllergySeverity Severity { get; set; }
        [Required]
        public string Reaction { get; set; }
        [Required]
        public DateTime DiagnosedDate { get; set; }
    }

}
