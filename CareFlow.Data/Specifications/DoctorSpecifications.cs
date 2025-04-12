using CareFlow.Data.Entities;

namespace CareFlow.Core.Specifications
{
    public class DoctorSpecifications : BaseSpecification<Doctor>
    {
        public DoctorSpecifications(Guid id) : base(d => d.Id == id)
        {
            Includes.Add(d => d.Specializations);
        }

        public DoctorSpecifications()
        {
            Includes.Add(d => d.Specializations);
        }
    }
}
