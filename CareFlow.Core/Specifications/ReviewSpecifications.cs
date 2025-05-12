using CareFlow.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Specifications
{
   public class ReviewSpecifications : BaseSpecification<Review>
    {
        public ReviewSpecifications(Guid id,string userId):base(r=>r.Id==id&& r.Patient.AppUserId==userId)
        {

            AddIncludes(q => q.Include(r => r.Patient));
            AddIncludes(q => q.Include(r => r.Doctor));
            AddIncludes(q => q.Include(r => r.Appointment));
        }
    }
}
