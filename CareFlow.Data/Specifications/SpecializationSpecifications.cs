using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Specifications
{
    public class SpecializationSpecifications : BaseSpecification<Specialization>
    {
        public SpecializationSpecifications(List<Guid> specializationIds) : base(s => specializationIds.Contains(s.Id))
        {

        }
    }
}
