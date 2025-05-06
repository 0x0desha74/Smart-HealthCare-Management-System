using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class DocumentSpecifications : BaseSpecification<Document>
    {
        public DocumentSpecifications(Guid id) : base(d => d.Id == id)
        {
            AddIncludes(q => q.Include(d => d.Patient));
            AddIncludes(q => q.Include(d => d.MedicalHistory).ThenInclude(m => m.Doctor));

        }
        public DocumentSpecifications(Guid id,string userId) : base(d => d.Id == id && d.Patient.AppUserId==userId)
        {
            AddIncludes(q => q.Include(d => d.Patient));
            AddIncludes(q => q.Include(d => d.MedicalHistory).ThenInclude(m => m.Doctor));

        }
        public DocumentSpecifications(DocumentFilterDto specParams, string patientUserId)
            : base(d =>
                  (d.Patient.AppUserId == patientUserId) &&
                  (string.IsNullOrEmpty(specParams.Search) ||
                    d.OriginalFileName.ToLower().Contains(specParams.Search))
                  )
        {
            AddIncludes(q => q.Include(d => d.Patient));
            AddIncludes(q => q.Include(d => d.MedicalHistory).ThenInclude(m => m.Doctor));
            ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        }
    }
}
