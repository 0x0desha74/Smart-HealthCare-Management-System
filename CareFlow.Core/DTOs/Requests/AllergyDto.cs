using CareFlow.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

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
