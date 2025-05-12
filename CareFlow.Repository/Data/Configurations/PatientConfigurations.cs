using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareFlow.Repository.Data.Configurations
{
    public class PatientConfigurations : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(p => p.bloodType)
                 .HasConversion<string>();
            builder.Property(p => p.Gender)
                 .HasConversion<string>();

            builder.HasOne(p => p.Doctor)
                .WithMany(d => d.Patients)
                .HasForeignKey(p => p.DoctorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Appointments)
                .WithOne(d => d.Patient)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PhoneNumbers)
             .WithOne(pn => pn.Patient)
             .HasForeignKey(pn => pn.PatientId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Allergies)
            .WithOne()
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Documents)
           .WithOne(d => d.Patient)
           .HasForeignKey(a => a.PatientId)
           .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Reviews)
                .WithOne(r => r.Patient)
                .HasForeignKey(r => r.PatientId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
