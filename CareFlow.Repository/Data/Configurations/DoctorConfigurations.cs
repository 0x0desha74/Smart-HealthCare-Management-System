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
        }
    }
}
