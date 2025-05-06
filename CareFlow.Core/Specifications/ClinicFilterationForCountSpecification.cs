using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Data.Entities;

namespace CareFlow.Core.Specifications
{
   public class ClinicFilterationForCountSpecification:BaseSpecification<Clinic>
    {
        public ClinicFilterationForCountSpecification(ClinicFilterDto specParams)
            : base(c =>
                (string.IsNullOrEmpty(specParams.Search) ||
            c.Name.ToLower().Contains(specParams.Search) ||
            c.Location.Country.ToLower().Contains(specParams.Search) ||
            c.Location.City.ToLower().Contains(specParams.Search) ||
            c.Location.Street.ToLower().Contains(specParams.Search) ||
            c.Location.AddressLine1.ToLower().Contains(specParams.Search))

                 )
        {

        }
    }
}
