using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Specifications
{
    public class DoctorSpecifications : BaseSpecification<Doctor>
    {
        public DoctorSpecifications(Guid id):base(d=>d.Id == id)
        {
            Includes.Add(d => d.Specializations);
        }

        public DoctorSpecifications()
        {
            Includes.Add(d => d.Specializations);
        }
    }
}
