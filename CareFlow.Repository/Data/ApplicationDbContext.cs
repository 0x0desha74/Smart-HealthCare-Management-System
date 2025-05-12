using CareFlow.Core.Entities;
using CareFlow.Core.Interfaces;
using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace CareFlow.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var filter = Expression.Lambda(
                        Expression.Equal(
                            Expression.Property(parameter, nameof(ISoftDeletable.IsDeleted)),
                            Expression.Constant(false)
                        ),
                        parameter
                    );

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
                }
            }

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
