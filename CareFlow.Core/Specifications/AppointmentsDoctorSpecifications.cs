using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class AppointmentsDoctorSpecifications : BaseSpecification<Appointment>
    {
        public AppointmentsDoctorSpecifications(SpecificationParameters specParams, string userId)
            : base(a => a.Doctor.AppUserId == userId &&
           (string.IsNullOrEmpty(specParams.Search) ||
           (a.Clinic != null && a.Clinic.Name.ToLower().Contains(specParams.Search)) ||
            (a.Doctor.FirstName != null && a.Patient.FirstName.ToLower().Contains(specParams.Search)) ||
            (a.Doctor.LastName != null && a.Patient.LastName.ToLower().Contains(specParams.Search))
            ))
        {
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.PhoneNumbers));
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.Allergies));
            AddIncludes(q => q.Include(a => a.Doctor).ThenInclude(p => p.Specializations));
            AddIncludes(q => q.Include(a => a.Clinic).ThenInclude(p => p.Location));
            ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        }


        public AppointmentsDoctorSpecifications(Guid id, string userId) : base(a => a.Id == id && a.Doctor.AppUserId == userId)
        {
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.PhoneNumbers));
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.Allergies));
            AddIncludes(q => q.Include(a => a.Doctor).ThenInclude(p => p.Specializations));
            AddIncludes(q => q.Include(a => a.Clinic).ThenInclude(p => p.Location));

        }
    }
}
