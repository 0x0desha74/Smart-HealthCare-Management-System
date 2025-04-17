using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Specifications
{
    public class PrescriptionPatientSpecifications:BaseSpecification<Prescription>
    {
        public PrescriptionPatientSpecifications(Guid patientId):base(p=>p.PatientId==patientId)
        {

        }
    }
}
