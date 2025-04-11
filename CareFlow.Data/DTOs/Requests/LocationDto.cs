using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.Requests
{
   public class LocationDto
    {
        public Guid Id { get; set; }
        [MaxLength(500)]
        [Required]
        public string AddressLine1 { get; set; }
        [MaxLength(50)]
        [Required]
        public string Country { get; set; }
        [MaxLength(50)]
        [Required]
        public string City { get; set; }
        [MaxLength(100)]
        [Required]
        public string Street { get; set; }
        [MaxLength(20)]
        [Required]
        public string PostalCode { get; set; }
    }
}
