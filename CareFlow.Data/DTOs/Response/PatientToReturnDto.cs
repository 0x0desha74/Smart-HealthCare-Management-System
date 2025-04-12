using CareFlow.Data.Entities.Enums;

namespace CareFlow.Core.DTOs.Response
{
    public class PatientToReturnDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public BloodType bloodType { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public ICollection<PhoneToReturnDto> PhoneNumbers { get; set; }
        public ICollection<AllergyToReturnDto> Allergies { get; set; }
    }
}
