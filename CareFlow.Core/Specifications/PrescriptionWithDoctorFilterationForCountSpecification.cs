using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Specifications
{
    public class PrescriptionWithDoctorFilterationForCountSpecification:BaseSpecification<Prescription>
    {
        public PrescriptionWithDoctorFilterationForCountSpecification(PrescriptionFilterDto specParams, string userId)
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
        }
    }
}
