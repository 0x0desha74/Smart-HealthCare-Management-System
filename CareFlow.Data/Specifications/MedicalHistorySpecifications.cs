using CareFlow.Core.Entities;

namespace CareFlow.Core.Specifications
{
    public class MedicalHistorySpecifications : BaseSpecification<MedicalHistory>
    {
        public MedicalHistorySpecifications(Guid patientId) : base(m => m.PatientId == patientId)
        {

        }
    }
}
