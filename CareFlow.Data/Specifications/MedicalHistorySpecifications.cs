using CareFlow.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class MedicalHistorySpecifications : BaseSpecification<MedicalHistory>
    {
        public MedicalHistorySpecifications(Guid id) : base(m => m.Id == id)
        {
            AddIncludes(q => q.Include(m => m.Patient));
            AddIncludes(q => q.Include(m => m.Doctor));
            AddIncludes(q => q.Include(m => m.Prescriptions));
        }
        public MedicalHistorySpecifications(string doctorUserId) : base(m => m.Doctor.AppUserId== doctorUserId)
        {
            AddIncludes(q => q.Include(m => m.Patient));
            AddIncludes(q => q.Include(m => m.Doctor));
            AddIncludes(q => q.Include(m => m.Prescriptions));
        }
    }
}
