using CareFlow.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.DTOs.Identity
{
    public class DoctorRegisterDto : RegisterDto
    {

        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public List<Guid> SpecializationsIds { get; set; }
        [Required]
        public string LicenceNumber { get; set; }
        [Required]
        public int YearOfExperience { get; set; }
        [Required]
        public Gender Gender { get; set; }


    }
}
