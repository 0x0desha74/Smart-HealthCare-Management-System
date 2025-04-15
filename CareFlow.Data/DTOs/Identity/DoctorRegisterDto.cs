using CareFlow.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
