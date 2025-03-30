using CareFlow.Core.Entities;
using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Repository.Data
{
   public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Clinic> Clinics{ get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Document> Documents{ get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
    }
}
