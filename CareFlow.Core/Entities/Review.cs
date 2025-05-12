using CareFlow.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.Entities
{
    public class Review : BaseEntity
    {
        [MaxLength(2000)]
        public string? Comment { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Doctor Doctor { get; set; }
        public Guid DoctorId { get; set; }
        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }
        public Appointment Appointment { get; set; }
        public Guid AppointmentId { get; set; }
    }
}
