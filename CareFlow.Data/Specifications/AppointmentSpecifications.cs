using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace CareFlow.Core.Specifications
{
    public class AppointmentSpecifications : BaseSpecification<Appointment>
    {

        public AppointmentSpecifications(SpecificationParameters specParams)
            : base(a =>
            (string.IsNullOrEmpty(specParams.Search) ||
            a.Clinic != null && a.Clinic.Name.ToLower().Contains(specParams.Search) ||
            a.Doctor.FirstName != null && a.Doctor.FirstName.ToLower().Contains(specParams.Search) ||
            a.Doctor.LastName != null && a.Doctor.LastName.ToLower().Contains(specParams.Search)
            ))
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

        public AppointmentSpecifications(Guid id, Guid patientId, Guid doctorId) : base(a => a.Id == id && a.DoctorId == doctorId && a.PatientId == patientId)
        {
        }
    }
}
