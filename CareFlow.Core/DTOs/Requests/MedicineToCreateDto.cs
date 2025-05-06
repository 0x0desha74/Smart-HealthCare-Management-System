using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.DTOs.Requests
{
    public class MedicineToCreateDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(2500)]
        public string Description { get; set; }
        [Required, MaxLength(100)]
        public string Manufacture { get; set; }
        [Required, MaxLength(100)]
        public string Category { get; set; }
    }
}
