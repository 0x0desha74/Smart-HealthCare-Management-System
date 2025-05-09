﻿using System.ComponentModel.DataAnnotations;

namespace CareFlow.Data.Entities
{
    public class Medicine : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(2500)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string Manufacture { get; set; }
        [MaxLength(100)]
        public string Category { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
    }
}
