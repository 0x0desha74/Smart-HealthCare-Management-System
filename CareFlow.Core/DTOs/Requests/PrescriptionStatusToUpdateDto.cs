using CareFlow.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.DTOs.Requests
{
    public class PrescriptionStatusToUpdateDto
    {
        [Required]
        public PrescriptionStatus Status { get; set; }
    }
}
