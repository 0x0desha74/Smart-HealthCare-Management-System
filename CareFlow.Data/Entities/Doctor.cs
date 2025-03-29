using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Data.Entities
{
   public class Doctor:BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string LicenceNumber { get; set; }
        public string PictureUrl { get; set; }
        public int YearOfExperience { get; set; }   
        public ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
        public ICollection<Specialization> Specializations { get; set; } = new HashSet<Specialization>();
        public Clinic Clinic { get; set; }
        
        public Guid ClinicId { get; set; }
    }
}
