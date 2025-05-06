using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Data.Entities;

namespace CareFlow.Core.Specifications
{
    public class DoctorFilterationForCountSpecification : BaseSpecification<Doctor>
    {
        public DoctorFilterationForCountSpecification(DoctorFilterDto specParams)
                 : base(d =>
                 (string.IsNullOrEmpty(specParams.Search) ||
                 (d.FirstName + " " + d.LastName).ToLower().Contains(specParams.Search) ||
                 (d.Specializations.Any(s => s.Name.ToLower().Contains(specParams.Search))) ||
                 (d.Clinic.Name.ToLower().Contains(specParams.Search))) &&
            (string.IsNullOrEmpty(specParams.Clinic) ||
            (d.Clinic != null || d.Clinic.Name.ToLower().Contains(specParams.Clinic))

            ))
        {

        }

    }
}