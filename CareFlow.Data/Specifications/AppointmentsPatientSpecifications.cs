using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class AppointmentsPatientSpecifications : BaseSpecification<Appointment>
    {
        public AppointmentsPatientSpecifications(string userId) : base(a => a.Patient.AppUserId == userId)
        {
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.PhoneNumbers));
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.Allergies));
            AddIncludes(q => q.Include(a => a.Doctor).ThenInclude(p => p.Specializations));
            AddIncludes(q => q.Include(a => a.Clinic).ThenInclude(p => p.Location));

        }

        public AppointmentsPatientSpecifications(Guid id, string userId) : base(a => a.Id == id && a.Patient.AppUserId == userId)
        {
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.PhoneNumbers));
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.Allergies));
            AddIncludes(q => q.Include(a => a.Doctor).ThenInclude(p => p.Specializations));
            AddIncludes(q => q.Include(a => a.Clinic).ThenInclude(p => p.Location));

        }
    }
}
