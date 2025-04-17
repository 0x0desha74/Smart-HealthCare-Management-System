using CareFlow.Data.Entities;

namespace CareFlow.Core.Specifications
{
    public class PrescriptionPatientSpecifications : BaseSpecification<Prescription>
    {
        public PrescriptionPatientSpecifications(Guid patientId) : base(p => p.PatientId == patientId)
        {

        }

        public PrescriptionPatientSpecifications(Guid patientId,Guid prescriptionId) : base(p => p.PatientId == patientId&&p.Id== prescriptionId)
        {

        }
    }
}
