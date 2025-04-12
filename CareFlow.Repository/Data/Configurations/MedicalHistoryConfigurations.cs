using CareFlow.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareFlow.Repository.Data.Configurations
{
    public class MedicalHistoryConfigurations : IEntityTypeConfiguration<MedicalHistory>
    {
        public void Configure(EntityTypeBuilder<MedicalHistory> builder)
        {
            builder.Property(m => m.Status)
                .HasConversion<string>();

            builder.HasOne(m => m.Patient)
                .WithMany(p => p.MedicalHistories)
                .HasForeignKey(m => m.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.Doctor)
                .WithMany(p => p.MedicalHistories)
                .HasForeignKey(m => m.DoctorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(m => m.Prescriptions)
                .WithOne()
                .HasForeignKey(p => p.MedicalHistoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.Instructions)
            .WithOne()
            .HasForeignKey(p => p.MedicalHistoryId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(m => m.Documents)
           .WithOne()
           .HasForeignKey(p => p.MedicalHistoryId)
           .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
