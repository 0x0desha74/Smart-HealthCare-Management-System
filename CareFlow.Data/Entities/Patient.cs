using CareFlow.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Data.Entities
{
    public class Patient:BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public BloodType bloodType{ get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

       
        public Guid DoctorId { get; set; }
        public Appointment Appointment { get; set; }
       
        public Doctor Doctor { get; set; }
        public Guid AppointmentId { get; set; }

    }
}
