using CareFlow.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.DTOs.Response
{
    public class AppointmentToReturnDto
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int DurationMinutes { get; set; }
        public AppointmentStatus Status { get; set; }
        [MaxLength(2500)]
        public string Reason { get; set; }
        [MaxLength(1000)]
        public string? Notes { get; set; }

        public Guid PatientId { get; set; }
        public string Patient { get; set; }

        public Guid DoctorId { get; set; }
        public string Doctor { get; set; }

        public Guid ClinicId { get; set; }
        public string Clinic { get; set; }

    }
}
