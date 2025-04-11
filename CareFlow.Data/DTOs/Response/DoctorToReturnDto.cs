using CareFlow.Core.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.Response
{
    public class DoctorToReturnDto
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string LicenceNumber { get; set; }
        public string PictureUrl { get; set; }
        public int YearOfExperience { get; set; }
        public ICollection<SpecializationDto> Specializations { get; set; }
    }
}
