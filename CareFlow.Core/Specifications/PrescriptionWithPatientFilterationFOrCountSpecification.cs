using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace CareFlow.Core.Specifications
{
    public class PrescriptionWithPatientFilterationFOrCountSpecification : BaseSpecification<Prescription>
    {
        public PrescriptionWithPatientFilterationFOrCountSpecification(PrescriptionFilterDto specParams, string userId)
            : base(a =>

          (a.Patient.AppUserId == userId) &&

          (string.IsNullOrEmpty(specParams.Search) ||
          (a.Doctor != null && (a.Doctor.FirstName + " " + a.Doctor.LastName).ToLower().Contains(specParams.Search))) &&

          (specParams.Status == null || a.Status == specParams.Status) &&
          (!specParams.StartDate.HasValue || a.IssueDate >= specParams.StartDate) &&
          (!specParams.EndDate.HasValue || a.IssueDate <= specParams.EndDate)

               )
        {
            AddIncludes(q => q.Include(p => p.Instructions));
            AddIncludes(q => q.Include(p => p.Doctor));
            AddIncludes(q => q.Include(p => p.Patient));
            AddIncludes(q => q.Include(p => p.Medicines));
        }
    }
}
