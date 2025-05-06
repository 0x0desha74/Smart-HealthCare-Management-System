using CareFlow.Data.Entities.Enums;

namespace CareFlow.Core.DTOs.Response
{
    public class PhoneToReturnDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public bool IsPrimary { get; set; }
        public PhoneType PhoneType { get; set; }
    }
}