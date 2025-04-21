using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Specifications
{
   public class PrescriptionDoctorSpecifications:BaseSpecification<Prescription>
    {
        public PrescriptionDoctorSpecifications(string userId):base(p=>p.Doctor.AppUserId==userId)
        {
            AddIncludes(q => q.Include(p => p.Instructions));
            AddIncludes(q => q.Include(p => p.Doctor));
            AddIncludes(q => q.Include(p => p.Patient));
            AddIncludes(q => q.Include(p => p.Medicines));
        }
    }
}
