using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Specifications
{
   public class AppointmentWithFilterationForCountSpecification : BaseSpecification<Appointment>
    {
        public AppointmentWithFilterationForCountSpecification(SpecificationParameters specParams)
             : base(a =>
           (string.IsNullOrEmpty(specParams.Search) ||
           (a.Clinic != null && a.Clinic.Name.ToLower().Contains(specParams.Search)) ||
            (a.Doctor.FirstName != null && a.Doctor.FirstName.ToLower().Contains(specParams.Search)) ||
            (a.Doctor.LastName != null && a.Doctor.LastName.ToLower().Contains(specParams.Search))
            ))
        {

        }
    }
}
