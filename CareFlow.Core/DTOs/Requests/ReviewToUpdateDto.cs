using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.DTOs.Requests
{
    public class ReviewToUpdateDto
    {
        [MaxLength(2000)]
        public string? Comment { get; set; }
        [Required, Range(1, 5)]
        public int Rating { get; set; }
    }
}
