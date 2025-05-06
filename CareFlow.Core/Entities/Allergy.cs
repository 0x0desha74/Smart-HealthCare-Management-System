using CareFlow.Data.Entities.Enums;

namespace CareFlow.Data.Entities
{
    public class Allergy : BaseEntity
    {
        public string Name { get; set; }
        public AllergySeverity Severity { get; set; }
        public string Reaction { get; set; }
        public DateTime DiagnosedDate { get; set; }
        public Guid PatientId { get; set; }
    }
}
