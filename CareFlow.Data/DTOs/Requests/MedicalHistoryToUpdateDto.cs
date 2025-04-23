using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Core.DTOs.Requests
{
   public class MedicalHistoryToUpdateDto
    {

        public string Diagnosis { get; set; }
        public string TreatmentSummary { get; set; }
        public string ClinicalNotes { get; set; }
        public DateTime OnSetDate { get; set; }
        public bool RequiredFollowUp { get; set; }
        public DateTime FollowUpDate { get; set; }
     
    }
}
