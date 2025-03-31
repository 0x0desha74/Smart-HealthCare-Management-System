using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Specifications
{
    public class PatientSpecifications : BaseSpecification<Patient>
    {
        public PatientSpecifications()
        {
            Includes.Add(p => p.Allergies);
            Includes.Add(p => p.PhoneNumbers);
            
        }

        public PatientSpecifications(Guid id) : base(p => p.Id == id)
        {
            Includes.Add(p => p.Allergies);
            Includes.Add(p => p.PhoneNumbers);
           
        }
}

}