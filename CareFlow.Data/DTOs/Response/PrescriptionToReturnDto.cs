using CareFlow.Data.Entities.Enums;
using CareFlow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.Response
{
    public class PrescriptionToReturnDto
    {
        public Guid Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Instruction { get; set; }
        public PrescriptionStatus Status { get; set; }
        public Guid PatientId { get; set; }
        public string Patient { get; set; }
        public Guid DoctorId { get; set; }
        public string Doctor { get; set; }
        public ICollection<MedicineToReturnDto> Medicines { get; set; }

    }
}
