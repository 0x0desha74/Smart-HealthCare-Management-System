﻿using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Data.Entities;
using CareFlow.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace CareFlow.Core.Specifications
{
    public class UpcomingPatientAppointmentSpecifications : BaseSpecification<Appointment>
    {
        public UpcomingPatientAppointmentSpecifications(PaginationDto specParams, string userId) : base(a => a.Patient.AppUserId == userId && a.Status == AppointmentStatus.Pending)
        {
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.PhoneNumbers));
            AddIncludes(q => q.Include(a => a.Patient).ThenInclude(p => p.Allergies));
            AddIncludes(q => q.Include(a => a.Doctor).ThenInclude(p => p.Specializations));
            AddIncludes(q => q.Include(a => a.Clinic).ThenInclude(p => p.Location));
            ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        }
    }
}
