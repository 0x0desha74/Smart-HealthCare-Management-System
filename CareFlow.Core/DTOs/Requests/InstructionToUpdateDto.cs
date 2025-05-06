using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.DTOs.Requests
{
    public class InstructionToUpdateDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required, MaxLength(2500)]
        public string Description { get; set; }
    }
}
