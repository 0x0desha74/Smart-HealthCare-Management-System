using CareFlow.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class MedicalHistoryWithPatientIdSpecifications : BaseSpecification<MedicalHistory>
    {
        public MedicalHistoryWithPatientIdSpecifications(Guid patientId) : base(m => m.PatientId == patientId)
        {
            AddIncludes(q => q.Include(m => m.Patient));
            AddIncludes(q => q.Include(m => m.Doctor));
            AddIncludes(q => q.Include(m => m.Prescriptions));
        }

    }
}
