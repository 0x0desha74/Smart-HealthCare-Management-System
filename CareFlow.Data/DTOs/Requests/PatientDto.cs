using CareFlow.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.DTOs.In
{
    public class PatientDto
    {
        [Required]
        public Guid id { get; set; }
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public BloodType bloodType { get; set; }
        [Required]
        [Range(0, 300)]
        public double Height { get; set; }
        [Required]
        [Range(0, 500)]
        public double Weight { get; set; }
        public Guid? DoctorId { get; set; }
    }
}
