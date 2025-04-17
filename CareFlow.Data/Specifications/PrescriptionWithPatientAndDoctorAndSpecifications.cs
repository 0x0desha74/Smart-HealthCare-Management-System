using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Specifications
{
    public class PrescriptionWithPatientAndDoctorAndSpecifications:BaseSpecification<Prescription>
    {
        public PrescriptionWithPatientAndDoctorAndSpecifications(Guid medicalHistoryId):base(p=>p.MedicalHistoryId==medicalHistoryId)
        {
            AddIncludes(q => q.Include(p => p.Patient));
            AddIncludes(q => q.Include(p => p.Doctor));
        }
    }
}
