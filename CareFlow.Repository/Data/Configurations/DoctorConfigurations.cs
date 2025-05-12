using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareFlow.Repository.Data.Configurations
{
    public class DoctorConfigurations : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasMany(d => d.Specializations)
                .WithMany(s => s.Doctors);

            builder.Property(d => d.Gender)
                .HasConversion<string>();

            builder.Property(d => d.Fees)
                .HasColumnType("decimal(18,2)");

            builder.HasMany(p => p.Reviews)
                .WithOne(r => r.Doctor)
                .HasForeignKey(r => r.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
