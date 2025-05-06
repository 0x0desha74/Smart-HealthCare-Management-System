using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class DoctorSpecifications : BaseSpecification<Doctor>
    {
        public DoctorSpecifications(Guid id) : base(d => d.Id == id)
        {
            AddIncludes(q => q.Include(d => d.Specializations));
        }

        public DoctorSpecifications(DoctorFilterDto specParams)
            : base(d =>
                 (string.IsNullOrEmpty(specParams.Search) ||
                 (d.FirstName + " " + d.LastName).ToLower().Contains(specParams.Search) ||
                 (d.Specializations.Any(s => s.Name.ToLower().Contains(specParams.Search))) ||
                 (d.Clinic.Name.ToLower().Contains(specParams.Search))) &&
            (string.IsNullOrEmpty(specParams.Clinic) ||
            (d.Clinic != null || d.Clinic.Name.ToLower().Contains(specParams.Clinic))

            ))
        {
            AddIncludes(q => q.Include(d => d.Specializations));
            AddIncludes(q => q.Include(d => d.Clinic));
            ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

        }
        public DoctorSpecifications(string userId) : base(d => d.AppUserId == userId)
        {
            AddIncludes(q => q.Include(d => d.Specializations));
        }
    }
}