using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.Requests
{
    public class DoctorDto
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(100)]
        [Required]
        public string LicenceNumber { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public int YearOfExperience { get; set; }
        [Required]
        public List<Guid> SpecializationsIds { get; set; }
    }
}
