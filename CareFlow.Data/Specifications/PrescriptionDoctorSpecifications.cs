using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class PrescriptionDoctorSpecifications : BaseSpecification<Prescription>
    {
        public PrescriptionDoctorSpecifications(string userId) : base(p => p.Doctor.AppUserId == userId)
        {
            AddIncludes(q => q.Include(p => p.Instructions));
            AddIncludes(q => q.Include(p => p.Doctor));
            AddIncludes(q => q.Include(p => p.Patient));
            AddIncludes(q => q.Include(p => p.Medicines));
        }
        public PrescriptionDoctorSpecifications(Guid id) : base(p => p.Id== id)
        {
            AddIncludes(q => q.Include(p => p.Doctor));
        }
    }
}
