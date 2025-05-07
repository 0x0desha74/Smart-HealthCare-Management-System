using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Data.Entities;

namespace CareFlow.Core.Specifications
{
    public class PatientWithFilterationForCountSpecifications : BaseSpecification<Patient>
    {
        public PatientWithFilterationForCountSpecifications(PatientFilterDto specParams)
          : base(b =>
               string.IsNullOrEmpty(specParams.Search) ||
          (b.FirstName !=null && b.LastName  != null && (b.FirstName + " " + b.LastName).ToLower().Contains(specParams.Search))
          
          )
        { }



    }
}
