using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class PrescriptionPatientSpecifications : BaseSpecification<Prescription>
    {
        public PrescriptionPatientSpecifications(Guid patientId) : base(p => p.PatientId == patientId)
        {

        }
        public PrescriptionPatientSpecifications(PrescriptionFilterDto specParams, string userId)
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
            ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        }

        public PrescriptionPatientSpecifications(Guid patientId, Guid prescriptionId) : base(p => p.PatientId == patientId && p.Id == prescriptionId)
        {

        }
    }
}
