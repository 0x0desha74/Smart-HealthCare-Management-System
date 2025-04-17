using CareFlow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Specifications
{
   public class MedicalHistorySpecifications:BaseSpecification<MedicalHistory>
    {
        public MedicalHistorySpecifications(Guid patientId):base(m=>m.PatientId == patientId)
        {

        }
    }
}
