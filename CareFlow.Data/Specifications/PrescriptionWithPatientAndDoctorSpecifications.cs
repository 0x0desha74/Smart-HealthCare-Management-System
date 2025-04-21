using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class PrescriptionWithPatientAndDoctorSpecifications : BaseSpecification<Prescription>
    {
        public PrescriptionWithPatientAndDoctorSpecifications(Guid medicalHistoryId) : base(p => p.MedicalHistoryId == medicalHistoryId)
        {
            AddIncludes(q => q.Include(p => p.Patient));
            AddIncludes(q => q.Include(p => p.Doctor));
            AddIncludes(q => q.Include(p => p.Medicines));
            AddIncludes(q => q.Include(p => p.Instructions));
        }
    }
}
