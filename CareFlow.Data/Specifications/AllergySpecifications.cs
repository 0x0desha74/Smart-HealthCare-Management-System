using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Specifications
{
   public class AllergySpecifications:BaseSpecification<Allergy>
    {
        public AllergySpecifications(Guid patientId) : base(a => a.PatientId == patientId)
        {

        }
        public AllergySpecifications(Guid patientId, Guid allergyId):base(a=>a.Id==allergyId && a.PatientId==patientId)
        {

        }
    }
}
