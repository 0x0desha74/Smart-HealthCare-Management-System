using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class PatientSpecifications : BaseSpecification<Patient>
    {
        public PatientSpecifications(PatientFilterDto specParams)
            : base(b =>
               string.IsNullOrEmpty(specParams.Search) ||
          (b.FirstName != null && b.LastName != null && (b.FirstName + " " + b.LastName).ToLower().Contains(specParams.Search))

          )
        {
            AddIncludes(q => q.Include(p => p.Allergies));
            AddIncludes(q => q.Include(p => p.PhoneNumbers));
            ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        }

        public PatientSpecifications(Guid id) : base(p => p.Id == id)
        {
            AddIncludes(q => q.Include(p => p.Allergies));
            AddIncludes(q => q.Include(p => p.PhoneNumbers));
        }
    }

}