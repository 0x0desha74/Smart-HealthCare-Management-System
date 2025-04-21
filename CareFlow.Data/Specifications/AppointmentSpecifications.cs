using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace CareFlow.Core.Specifications
{
    public class AppointmentSpecifications : BaseSpecification<Appointment>
    {

        public AppointmentSpecifications()
        {
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.PhoneNumbers));
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.Allergies));
            AddIncludes(q => q.Include(a => a.Doctor).ThenInclude(p => p.Specializations));
            AddIncludes(q => q.Include(a => a.Clinic).ThenInclude(p => p.Location));

        }

        public AppointmentSpecifications(Guid id) : base(a => a.Id == id)
        {
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.PhoneNumbers));
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.Allergies));
            AddIncludes(q => q.Include(a => a.Doctor).ThenInclude(p => p.Specializations));
            AddIncludes(q => q.Include(a => a.Clinic).ThenInclude(p => p.Location));

        }

        public AppointmentSpecifications(Guid id, Guid patientId,Guid doctorId) : base(a=>a.Id == id&&a.DoctorId==doctorId&&a.PatientId==patientId)
        {
        }
    }
}
