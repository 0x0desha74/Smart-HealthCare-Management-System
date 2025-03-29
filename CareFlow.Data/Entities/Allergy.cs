using CareFlow.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Data.Entities
{
   public class Allergy:BaseEntity
    {
        public string Name { get; set; }
        public AllergySeverity Severity { get; set; }
        public string Reaction { get; set; }
        public DateTime DiagnosedDate{ get; set; }
        public Guid PatientId { get; set; }
    }
}
