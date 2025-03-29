using CareFlow.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareFlow.Repository.Data.Configurations
{
    public class InstructionConfigurations : IEntityTypeConfiguration<Instruction>
    {
        public void Configure(EntityTypeBuilder<Instruction> builder)
        {
            builder.HasOne(i => i.Patient)
            .WithMany()
            .HasForeignKey(i=> i.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.Doctor)
            .WithMany()
            .HasForeignKey(i => i.DoctorId)
            .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
