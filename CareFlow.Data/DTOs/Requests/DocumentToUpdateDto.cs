using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.DTOs.Requests
{
    public class DocumentToUpdateDto
    {
        public bool? IsActive { get; set; }
        [Required]
        public string Version { get; set; }
    }
}
