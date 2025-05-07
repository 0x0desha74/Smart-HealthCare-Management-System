using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class PrescriptionDoctorSpecifications : BaseSpecification<Prescription>
    {
        public PrescriptionDoctorSpecifications(PrescriptionFilterDto specParams, string userId)
              : base(a =>

            (a.Doctor.AppUserId == userId) &&

            (string.IsNullOrEmpty(specParams.Search) ||
            (a.Patient != null && (a.Patient.FirstName + " " + a.Patient.LastName).ToLower().Contains(specParams.Search))) &&

            (specParams.Status == null || a.Status == specParams.Status) &&
            (!specParams.StartDate.HasValue || a.IssueDate >= specParams.StartDate) &&
            (!specParams.EndDate.HasValue || a.IssueDate <= specParams.EndDate)

                 )
        {
            AddIncludes(q => q.Include(p => p.Instructions));
            AddIncludes(q => q.Include(p => p.Doctor));
            AddIncludes(q => q.Include(p => p.Patient));
            AddIncludes(q => q.Include(p => p.Medicines));
            ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        }
        public PrescriptionDoctorSpecifications(Guid id) : base(p => p.Id == id)
        {
            AddIncludes(q => q.Include(p => p.Doctor));
        }
    }
}
