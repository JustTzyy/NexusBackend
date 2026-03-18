using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class TeacherAssignmentConfiguration : IEntityTypeConfiguration<TeacherAssignment>
    {
        public void Configure(EntityTypeBuilder<TeacherAssignment> builder)
        {
            builder.ToTable("TeacherAssignments");

            builder.HasKey(t => t.Id);

            // Teacher relationship
            builder.HasOne(t => t.Teacher)
                .WithMany()
                .HasForeignKey(t => t.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            // Building relationship
            builder.HasOne(t => t.Building)
                .WithMany()
                .HasForeignKey(t => t.BuildingId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department relationship
            builder.HasOne(t => t.Department)
                .WithMany()
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Audit relationships from BaseEntity
            builder.HasOne(t => t.CreatedByUser)
                .WithMany()
                .HasForeignKey(t => t.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.UpdatedByUser)
                .WithMany()
                .HasForeignKey(t => t.UpdatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
