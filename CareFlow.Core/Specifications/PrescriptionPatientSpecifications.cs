using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class PrescriptionPatientSpecifications : BaseSpecification<Prescription>
    {
        public PrescriptionPatientSpecifications(Guid patientId) : base(p => p.PatientId == patientId)
        {

        }
        public PrescriptionPatientSpecifications(string userId) : base(p => p.Patient.AppUserId == userId)
        {
            AddIncludes(q => q.Include(p => p.Instructions));
            AddIncludes(q => q.Include(p => p.Doctor));
            AddIncludes(q => q.Include(p => p.Patient));
            AddIncludes(q => q.Include(p => p.Medicines));
        }

        public PrescriptionPatientSpecifications(Guid patientId, Guid prescriptionId) : base(p => p.PatientId == patientId && p.Id == prescriptionId)
        {

        }
    }
}
