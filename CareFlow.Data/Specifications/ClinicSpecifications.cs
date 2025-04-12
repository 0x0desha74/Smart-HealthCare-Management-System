using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class ClinicSpecifications : BaseSpecification<Clinic>
    {

        public ClinicSpecifications(Guid id) : base(c => c.Id == id)
        {
            AddIncludes(q => q.Include(c => c.Location));
        }
        public ClinicSpecifications()
        {
            AddIncludes(q => q.Include(c => c.Location));
        }
    }
}
