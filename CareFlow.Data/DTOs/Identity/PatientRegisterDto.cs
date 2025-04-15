using CareFlow.Core.DTOs.Requests;
using CareFlow.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
