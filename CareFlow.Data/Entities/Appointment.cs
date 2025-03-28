﻿using CareFlow.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Data.Entities
{
   public class Appointment:BaseEntity
    {
        public DateTime AppointmentDate { get; set; }
        public int DurationMinutes { get; set; }
        public AppointmentStatus Status { get; set; }
        [MaxLength(2500)]
        public string Reason { get; set; }
        [MaxLength(1000)]
        public string? Notes { get; set; }

        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }

        public Doctor Doctor { get; set; }  
        public Clinic Clinic { get; set; }

        public Guid DoctorId { get; set; }
        public Guid ClinicId { get; set; }
    }
}
