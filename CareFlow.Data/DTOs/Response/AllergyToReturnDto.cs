using CareFlow.Data.Entities.Enums;

namespace CareFlow.Core.DTOs.Response
{
    public class AllergyToReturnDto
    {
        public string Name { get; set; }
        public AllergySeverity Severity { get; set; }
        public string Reaction { get; set; }
        public DateTime DiagnosedDate { get; set; }
    }
}