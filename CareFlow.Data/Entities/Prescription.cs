using CareFlow.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Data.Entities
{
    public class Prescription:BaseEntity
    {
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Instruction { get; set; }
        public PrescriptionStatus Status{ get; set; }

        public Patient Patient { get; set; }
        public Guid PatientId{ get; set; }

        public Doctor Doctor { get; set; }
        public Guid DoctorID { get; set; }

        public ICollection<Medicine> Medicines { get; set; }

    }
}
