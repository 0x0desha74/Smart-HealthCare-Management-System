using System.ComponentModel.DataAnnotations;

namespace CareFlow.Data.Entities
{
    public class Specialization : BaseEntity
    {

        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(2500)]
        public string? Description { get; set; }
        public ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
    }
}
