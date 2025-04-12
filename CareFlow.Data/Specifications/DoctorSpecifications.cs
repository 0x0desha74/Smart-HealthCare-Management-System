using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class DoctorSpecifications : BaseSpecification<Doctor>
    {
        public DoctorSpecifications(Guid id) : base(d => d.Id == id)
        {
            AddIncludes(q => q.Include(d => d.Specializations));
        }

        public DoctorSpecifications()
        {
            AddIncludes(q => q.Include(d => d.Specializations));
        }
    }
}
