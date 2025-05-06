using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace CareFlow.Core.Specifications
{
    public class DocumentFilterationForCountSpecifications : BaseSpecification<Document>
    {
        public DocumentFilterationForCountSpecifications(DocumentFilterDto specParams, string patientUserId)
             : base(d =>
                   (d.Patient.AppUserId == patientUserId) &&
                   (string.IsNullOrEmpty(specParams.Search) ||
                     d.OriginalFileName.ToLower().Contains(specParams.Search))
                   )
        {
            AddIncludes(q => q.Include(d => d.Patient));
            AddIncludes(q => q.Include(d => d.MedicalHistory).ThenInclude(m => m.Doctor));

        }
    }

}

