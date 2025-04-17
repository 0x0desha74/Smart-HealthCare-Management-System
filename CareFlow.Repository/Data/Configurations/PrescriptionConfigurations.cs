using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareFlow.Repository.Data.Configurations
{
    public class PrescriptionConfigurations : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.Property(p => p.Status)
                .HasConversion<string>();

            builder.HasMany(p => p.Medicines)
                .WithMany(m => m.Prescriptions);

            builder.HasOne(p => p.Doctor)
                .WithMany()
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(m => m.Instructions)
           .WithOne()
           .HasForeignKey(i => i.PrescriptionId)
           .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Patient)
            .WithMany(pa => pa.Prescriptions)
            .HasForeignKey(p => p.PatientId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
