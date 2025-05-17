using CareFlow.Core.Entities;
using CareFlow.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareFlow.Data.Entities
{
    public class Doctor : BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string LicenceNumber { get; set; }
        public string? PictureUrl { get; set; }
        public string About { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthData { get; set; }
        public int YearOfExperience { get; set; }
        public string AppUserId { get; set; }
        public decimal Fees { get; set; }
        //public ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
        public ICollection<Specialization> Specializations { get; set; } = new HashSet<Specialization>();
        public ICollection<MedicalHistory> MedicalHistories { get; set; } = new HashSet<MedicalHistory>();
        public Clinic Clinic { get; set; }
        public Guid? ClinicId { get; set; }
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    }
}
