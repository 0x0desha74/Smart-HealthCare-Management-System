namespace CareFlow.Core.DTOs.Response
{
    public class ReviewToReturnDto
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Rating { get; set; }
        public string Patient { get; set; }
        public Guid PatientId { get; set; }
        public string Doctor { get; set; }
        public Guid DoctorId { get; set; }
        public Guid AppointmentId { get; set; }
    }
}
