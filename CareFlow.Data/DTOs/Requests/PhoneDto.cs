using CareFlow.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.Requests
{
   public class PhoneDto
    {
        public Guid Id { get; set; }
        [RegularExpression("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$")]
        [Required]
        public string Number { get; set; }
        [Required]
        public bool IsPrimary { get; set; }
        [Required]
        public PhoneType PhoneType { get; set; }
        //public Guid PatientId { get; set; }
    }
}
