using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Specifications
{
   public class ClinicSpecifications:BaseSpecification<Clinic>
    {

        public ClinicSpecifications(Guid id):base(c=>c.Id==id)
        {
            Includes.Add(c => c.Location);
        }
        public ClinicSpecifications()
        {
            Includes.Add(c => c.Location);
        }
    }
}
