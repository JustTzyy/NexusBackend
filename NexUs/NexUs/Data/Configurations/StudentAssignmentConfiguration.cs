using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class StudentAssignmentConfiguration : IEntityTypeConfiguration<StudentAssignment>
    {
        public void Configure(EntityTypeBuilder<StudentAssignment> builder)
        {
            builder.ToTable("StudentAssignments");

            builder.HasKey(s => s.Id);

            // Unique: one assignment row per student
            builder.HasIndex(s => s.StudentId).IsUnique();

            // Student relationship
            builder.HasOne(s => s.Student)
                .WithMany()
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // PreferredBuilding relationship (nullable)
            builder.HasOne(s => s.PreferredBuilding)
                .WithMany()
                .HasForeignKey(s => s.PreferredBuildingId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // Audit relationships from BaseEntity
            builder.HasOne(s => s.CreatedByUser)
                .WithMany()
                .HasForeignKey(s => s.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.UpdatedByUser)
                .WithMany()
                .HasForeignKey(s => s.UpdatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
