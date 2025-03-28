﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Data.Entities
{
    public class Clinic:BaseEntity
    {
        public string Name { get; set; }
        public TimeOnly OpeningTime { get; set; }
        public TimeOnly ClosingTime { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public bool IsOpen24Hours{ get; set; }
        public Location Location { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
        public ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
    }
}
