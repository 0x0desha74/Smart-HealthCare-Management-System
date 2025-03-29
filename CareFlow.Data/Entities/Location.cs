using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Data.Entities
{
   public class Location:BaseEntity
    {
        [MaxLength(500)]
        public string AddressLine1 { get; set; }
        [MaxLength(50)]
        public string Conuntry { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(100)]
        public string Street { get; set; }
        [MaxLength(20)]
        public string PostalCode { get; set; }
        public Guid ClinicId { get; set; }
    }
}
