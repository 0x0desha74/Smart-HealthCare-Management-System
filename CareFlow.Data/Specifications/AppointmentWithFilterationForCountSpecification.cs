using CareFlow.Core.DTOs.FilterDTOs;
using CareFlow.Data.Entities;
using CareFlow.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.Specifications
{
   public class AppointmentWithFilterationForCountSpecification : BaseSpecification<Appointment>
    {
        public AppointmentWithFilterationForCountSpecification(AppointmentFilterDto specParams,string userId)
             : base(a =>

            (a.Doctor.AppUserId == userId || a.Patient.AppUserId == userId) &&

            (string.IsNullOrEmpty(specParams.Search) ||
            (a.Notes != null && a.Notes.ToLower().Contains(specParams.Search)) ||
            (a.Reason != null && a.Reason.ToLower().Contains(specParams.Search))) &&

             (string.IsNullOrEmpty(specParams.Doctor) || (a.Doctor.FirstName + " " + a.Doctor.LastName).ToLower().Contains(specParams.Doctor)) &&
            (string.IsNullOrEmpty(specParams.Patient) || (a.Patient.FirstName + " " + a.Patient.LastName).ToLower().Contains(specParams.Patient)) &&

            ((string.IsNullOrEmpty(specParams.Clinic) || (a.Clinic != null && a.Clinic.Name.ToLower().Contains(specParams.Clinic)))) &&

            (specParams.Status == null || a.Status == specParams.Status) &&
            (!specParams.StartDate.HasValue || a.AppointmentDate >= specParams.StartDate) &&
            (!specParams.EndDate.HasValue || a.AppointmentDate <= specParams.EndDate)

                 )
        {

        }
        public AppointmentWithFilterationForCountSpecification( string userId) : base(a => a.Doctor.AppUserId == userId && a.Status == AppointmentStatus.Pending)
        {
         
        }

    }
}
