using CareFlow.Data.Entities;
using CareFlow.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class UpcomingPatientAppointmentsSpecifications : BaseSpecification<Appointment>
    {
        public UpcomingPatientAppointmentsSpecifications(string userId) : base(a => a.Doctor.AppUserId == userId && a.Status == AppointmentStatus.Pending)
        {
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.Allergies));
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.PhoneNumbers));
            AddIncludes(q => q.Include(a => a.Doctor).ThenInclude(p => p.Specializations));
            AddIncludes(q => q.Include(a => a.Clinic).ThenInclude(p => p.Location));
        }
    }
}
