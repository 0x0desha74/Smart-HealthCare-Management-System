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
        public DocumentSpecifications(string patientUserId) : base(d => d.Patient.AppUserId == patientUserId)
        {
            AddIncludes(q => q.Include(d => d.Patient));
            AddIncludes(q => q.Include(d => d.MedicalHistory).ThenInclude(m => m.Doctor));

        }
    }
}
