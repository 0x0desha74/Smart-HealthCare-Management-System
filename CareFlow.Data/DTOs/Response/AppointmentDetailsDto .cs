using CareFlow.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.Response
{
    public class AppointmentDetailsDto
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int DurationMinutes { get; set; }
        public AppointmentStatus Status { get; set; }
        [MaxLength(2500)]
        public string Reason { get; set; }
        [MaxLength(1000)]
        public string? Notes { get; set; }

        public PatientToReturnDto Patient { get; set; }

        public DoctorToReturnDto Doctor { get; set; }

        public ClinicToReturnDto Clinic { get; set; }
    }
}
