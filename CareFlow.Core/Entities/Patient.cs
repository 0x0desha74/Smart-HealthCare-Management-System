using CareFlow.Core.Entities;
using CareFlow.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CareFlow.Data.Entities
{
    public class Patient : BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public BloodType bloodType { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string AppUserId { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        //public Doctor Doctor { get; set; }
        public ICollection<Phone> PhoneNumbers { get; set; } = new HashSet<Phone>();
        public ICollection<Allergy> Allergies { get; set; } = new HashSet<Allergy>();
        public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
        public ICollection<Document> Documents { get; set; } = new HashSet<Document>();
        public ICollection<MedicalHistory> MedicalHistories { get; set; } = new HashSet<MedicalHistory>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        //public Guid? DoctorId { get; set; }
    }
}
