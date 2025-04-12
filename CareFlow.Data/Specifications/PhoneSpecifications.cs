using CareFlow.Data.Entities;

namespace CareFlow.Core.Specifications
{
    public class PhoneSpecifications : BaseSpecification<Phone>
    {
        public PhoneSpecifications(Guid patientId, Guid id) : base(p => p.Id == id && p.PatientId == patientId)
        {

        }

        public PhoneSpecifications(Guid patientId) : base(p => p.PatientId == patientId)
        {

        }
    }
}
