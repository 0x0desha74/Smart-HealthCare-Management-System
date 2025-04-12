using CareFlow.Data.Entities;

namespace CareFlow.Core.Specifications
{
    public class AllergySpecifications : BaseSpecification<Allergy>
    {
        public AllergySpecifications(Guid patientId) : base(a => a.PatientId == patientId)
        {

        }
        public AllergySpecifications(Guid patientId, Guid allergyId) : base(a => a.Id == allergyId && a.PatientId == patientId)
        {

        }
    }
}
