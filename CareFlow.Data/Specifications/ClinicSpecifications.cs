using CareFlow.Data.Entities;

namespace CareFlow.Core.Specifications
{
    public class ClinicSpecifications : BaseSpecification<Clinic>
    {

        public ClinicSpecifications(Guid id) : base(c => c.Id == id)
        {
            Includes.Add(c => c.Location);
        }
        public ClinicSpecifications()
        {
            Includes.Add(c => c.Location);
        }
    }
}
