using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class PatientSpecifications : BaseSpecification<Patient>
    {
        public PatientSpecifications()
        {
            AddIncludes(q => q.Include(p => p.Allergies));
            AddIncludes(q => q.Include(p => p.PhoneNumbers));
        }

        public PatientSpecifications(Guid id) : base(p => p.Id == id)
        {
            AddIncludes(q => q.Include(p => p.Allergies));
            AddIncludes(q => q.Include(p => p.PhoneNumbers));
        }
    }

}