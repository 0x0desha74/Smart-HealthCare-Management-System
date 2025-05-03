using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Specifications
{
    public class PatientWithFilterationForCountSpecifications : BaseSpecification<Patient>
    {
        public PatientWithFilterationForCountSpecifications(SpecificationParameters specParams)
          : base(b =>
               (string.IsNullOrEmpty(specParams.Search)) ||
          (b.FirstName != null && b.FirstName == specParams.Search) ||
          (b.LastName != null && b.LastName == specParams.Search) ||
          (b.LastName != null && b.LastName == specParams.Search)
          )
        { }



    }
}
