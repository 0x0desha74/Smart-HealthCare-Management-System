using CareFlow.Data.Entities.Enums;
using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.Requests
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public int DurationMinutes { get; set; }
        [Required]
        public AppointmentStatus Status { get; set; }
        [MaxLength(2500)]
        [Required]
        public string Reason { get; set; }
        [MaxLength(1000)]
        [Required]
        public string? Notes { get; set; }

        [Required]
        public Guid PatientId { get; set; }
        [Required]
        public Guid DoctorId { get; set; }
        [Required]
        public Guid ClinicId { get; set; }
    }
}
