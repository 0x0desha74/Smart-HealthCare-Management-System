using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Specifications
{
   public class ReviewWithFilterationForCountSpecifications : BaseSpecification<Review>
    {
        public ReviewWithFilterationForCountSpecifications(ReviewFilterDto specParams, Guid doctorId) : base(r => r.DoctorId == doctorId)
        {
            AddIncludes(q => q.Include(r => r.Patient));
            AddIncludes(q => q.Include(r => r.Doctor));
            AddIncludes(q => q.Include(r => r.Appointment));
        }
    }
}
