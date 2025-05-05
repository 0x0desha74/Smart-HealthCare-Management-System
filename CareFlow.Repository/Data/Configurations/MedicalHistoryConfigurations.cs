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
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Doctor)
                .WithMany(p => p.MedicalHistories)
                .HasForeignKey(m => m.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);





            builder.HasMany(m => m.Documents)
           .WithOne(d => d.MedicalHistory)
           .HasForeignKey(d => d.MedicalHistoryId)
           .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
