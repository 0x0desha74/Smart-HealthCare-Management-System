using System.ComponentModel.DataAnnotations;

namespace CareFlow.Data.Entities
{
    public class Location : BaseEntity
    {
        [MaxLength(500)]
        public string AddressLine1 { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(100)]
        public string Street { get; set; }
        [MaxLength(20)]
        public string PostalCode { get; set; }
        //public Guid ClinicId { get; set; }
    }
}
