using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class TeacherInterestConfiguration : IEntityTypeConfiguration<TeacherInterest>
    {
        public void Configure(EntityTypeBuilder<TeacherInterest> builder)
        {
            builder.ToTable("TeacherInterests");

            builder.HasKey(ti => ti.Id);

            builder.Property(ti => ti.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(ti => ti.Status)
                .IsRequired()
                .HasMaxLength(20);

            // Teacher relationship
            builder.HasOne(ti => ti.Teacher)
                .WithMany()
                .HasForeignKey(ti => ti.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            // Audit relationships from BaseEntity
            builder.HasOne(ti => ti.CreatedByUser)
                .WithMany()
                .HasForeignKey(ti => ti.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ti => ti.UpdatedByUser)
                .WithMany()
                .HasForeignKey(ti => ti.UpdatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
