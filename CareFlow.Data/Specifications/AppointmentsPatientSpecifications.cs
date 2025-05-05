using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class AppointmentsPatientSpecifications : BaseSpecification<Appointment>
    {
        public AppointmentsPatientSpecifications(SpecificationParameters specParams, string userId)
            : base(a => a.Patient.AppUserId == userId &&
           (string.IsNullOrEmpty(specParams.Search) ||
           (a.Clinic != null && a.Clinic.Name.ToLower().Contains(specParams.Search)) ||
            (a.Doctor.FirstName != null && a.Doctor.FirstName.ToLower().Contains(specParams.Search)) ||
            (a.Doctor.LastName != null && a.Doctor.LastName.ToLower().Contains(specParams.Search))
            ))
        {
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.PhoneNumbers));
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.Allergies));
            AddIncludes(q => q.Include(a => a.Doctor).ThenInclude(p => p.Specializations));
            AddIncludes(q => q.Include(a => a.Clinic).ThenInclude(p => p.Location));
            ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
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
