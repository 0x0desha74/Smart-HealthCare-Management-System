using CareFlow.Data.Entities;

namespace CareFlow.Core.Specifications
{
    public class PrescriptionPatientSpecifications : BaseSpecification<Prescription>
    {
        public PrescriptionPatientSpecifications(Guid patientId) : base(p => p.PatientId == patientId)
        {

        }
    }
}
