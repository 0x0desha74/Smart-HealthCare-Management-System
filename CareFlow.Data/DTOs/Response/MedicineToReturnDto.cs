using CareFlow.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace CareFlow.Core.DTOs.Response
{
    public class MedicineToReturnDto
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(2500)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string Manufacture { get; set; }
        [MaxLength(100)]
        public string Category { get; set; }
    }
}