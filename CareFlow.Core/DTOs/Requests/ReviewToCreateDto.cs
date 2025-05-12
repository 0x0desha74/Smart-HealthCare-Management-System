using System;
using System.ComponentModel.DataAnnotations;


namespace CareFlow.Core.DTOs.Requests
{
   public class ReviewToCreateDto
    {
        
        [MaxLength(20000)]
        public string? Comment { get; set; }
        [Required]
        public Guid AppointmentId { get; set; }
        [Required,Range(1,5)]
        public int Rating { get; set; }
        [Required]
        public Guid DoctorId { get; set; }
    }
}
