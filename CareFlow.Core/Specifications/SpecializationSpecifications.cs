using CareFlow.Data.Entities;

namespace CareFlow.Core.Specifications
{
    public class SpecializationSpecifications : BaseSpecification<Specialization>
    {
        public SpecializationSpecifications(List<Guid> specializationIds) : base(s => specializationIds.Contains(s.Id))
        {

        }
    }
}
