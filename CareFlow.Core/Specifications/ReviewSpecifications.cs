using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class ReviewSpecifications : BaseSpecification<Review>
    {
        public ReviewSpecifications(Guid id, string userId) : base(r => r.Id == id && r.Patient.AppUserId == userId)
        {

            AddIncludes(q => q.Include(r => r.Patient));
            AddIncludes(q => q.Include(r => r.Doctor));
            AddIncludes(q => q.Include(r => r.Appointment));
        }

        public ReviewSpecifications(ReviewFilterDto specParams, Guid doctorId) : base(r => r.DoctorId == doctorId)
        {
            AddIncludes(q => q.Include(r => r.Patient));
            AddIncludes(q => q.Include(r => r.Doctor));
            AddIncludes(q => q.Include(r => r.Appointment));

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "dateAsc":
                        AddOrderBy(r => r.CreatedAt);
                        break;
                    case "dateDesc":
                        AddOrderByDesc(r => r.CreatedAt);
                        break;
                    default:
                        AddOrderBy(r => r.CreatedAt);
                        break;
                }
            }
            else
            {
                AddOrderBy(r => r.CreatedAt);
            }
            ApplyPagination((specParams.PageIndex - 1) * specParams.PageSize, specParams.PageSize);
        }
    }
}
