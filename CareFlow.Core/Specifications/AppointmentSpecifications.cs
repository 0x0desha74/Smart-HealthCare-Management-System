using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace CareFlow.Core.Specifications
{
    public class AppointmentSpecifications : BaseSpecification<Appointment>
    {

        public AppointmentSpecifications(AppointmentFilterDto specParams, string userId)
            : base(a =>

            (a.Doctor.AppUserId == userId || a.Patient.AppUserId == userId) &&

            (string.IsNullOrEmpty(specParams.Search) ||
            (a.Notes != null && a.Notes.ToLower().Contains(specParams.Search)) ||
            (a.Reason != null && a.Reason.ToLower().Contains(specParams.Search))) &&

            (string.IsNullOrEmpty(specParams.Doctor) || (a.Doctor.FirstName + " " + a.Doctor.LastName).ToLower().Contains(specParams.Doctor)) &&
            (string.IsNullOrEmpty(specParams.Patient) || (a.Patient.FirstName + " " + a.Patient.LastName).ToLower().Contains(specParams.Patient)) &&

            ((string.IsNullOrEmpty(specParams.Clinic) || (a.Clinic != null && a.Clinic.Name.ToLower().Contains(specParams.Clinic)))) &&

            (specParams.Status == null || a.Status == specParams.Status) &&
            (!specParams.StartDate.HasValue || a.AppointmentDate >= specParams.StartDate) &&
            (!specParams.EndDate.HasValue || a.AppointmentDate <= specParams.EndDate)

                 )

        {
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.PhoneNumbers));
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.Allergies));
            AddIncludes(q => q.Include(a => a.Doctor).ThenInclude(p => p.Specializations));
            AddIncludes(q => q.Include(a => a.Clinic).ThenInclude(p => p.Location));
            AddOrderByDesc(a => a.AppointmentDate);

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "dateAsc":
                        AddOrderBy(a => a.AppointmentDate);
                        break;
                    case "dateDesc":
                        AddOrderByDesc(a => a.AppointmentDate);
                        break;
                    default:
                        AddOrderByDesc(a => a.AppointmentDate);
                        break;
                }
            }
            ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

        }

        public AppointmentSpecifications(Guid id)
            : base(a => a.Id == id)
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
