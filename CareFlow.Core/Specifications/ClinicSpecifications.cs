using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class ClinicSpecifications : BaseSpecification<Clinic>
    {

        public ClinicSpecifications(Guid id) : base(c => c.Id == id)
        {
            AddIncludes(q => q.Include(c => c.Location));
        }
        public ClinicSpecifications(ClinicFilterDto specParams)
            : base(c =>
                (string.IsNullOrEmpty(specParams.Search) ||
           (c.Location != null && c.Name.ToLower().Contains(specParams.Search)) ||
           (c.Location != null && c.Location.Country.ToLower().Contains(specParams.Search)) ||
           (c.Location != null && c.Location.City.ToLower().Contains(specParams.Search)) ||
           (c.Location != null && c.Location.Street.ToLower().Contains(specParams.Search)) ||
           (c.Location != null && c.Location.AddressLine1.ToLower().Contains(specParams.Search)))

                 )
        {
            AddIncludes(q => q.Include(c => c.Location));
            AddOrderBy(c => c.Name);

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "closingTimeAsc":
                        AddOrderBy(c => c.ClosingTime);
                        break;
                    case "openingTimeAsc":
                        AddOrderByDesc(c => c.OpeningTime);
                        break;
                    case "nameAsc":
                        AddOrderBy(c => c.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDesc(c => c.Name);
                        break;
                    default:
                        AddOrderBy(c => c.Name);
                        break;
                }

            }
            ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        }
    }
}
