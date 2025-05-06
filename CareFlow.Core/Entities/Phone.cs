using CareFlow.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareFlow.Data.Entities
{
    public class Phone : BaseEntity
    {
        [Phone]
        public string Number { get; set; }
        public bool IsPrimary { get; set; }
        public PhoneType PhoneType { get; set; }

        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }
    }
}
