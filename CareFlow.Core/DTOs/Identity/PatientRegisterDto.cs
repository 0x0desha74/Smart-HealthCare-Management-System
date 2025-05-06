using CareFlow.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.DTOs.Identity
{
    public class PatientRegisterDto : RegisterDto
    {

        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public Gender Gender { get; set; }


    }
}
