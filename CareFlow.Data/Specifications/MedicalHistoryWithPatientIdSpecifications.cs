using CareFlow.Core.Entities;

namespace CareFlow.Core.Specifications
{
    public class MedicalHistoryWithPatientIdSpecifications : BaseSpecification<MedicalHistory>
    {
        public MedicalHistoryWithPatientIdSpecifications(Guid patientId) : base(m => m.PatientId == patientId)
        {

        }

    }
}
