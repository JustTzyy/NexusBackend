using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class TutoringRequestConfiguration : IEntityTypeConfiguration<TutoringRequest>
    {
        public void Configure(EntityTypeBuilder<TutoringRequest> builder)
        {
            builder.ToTable("TutoringRequests");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Message)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(t => t.Priority)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.CancelledBy)
                .HasMaxLength(20);

            builder.Property(t => t.IsAdminCreated)
                .IsRequired()
                .HasDefaultValue(false);

            // Student relationship (nullable for admin-created requests)
            builder.HasOne(t => t.Student)
                .WithMany()
                .HasForeignKey(t => t.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

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

            // Subject relationship
            builder.HasOne(t => t.Subject)
                .WithMany()
                .HasForeignKey(t => t.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            // Assigned Teacher relationship
            builder.HasOne(t => t.AssignedTeacher)
                .WithMany()
                .HasForeignKey(t => t.AssignedTeacherId)
                .OnDelete(DeleteBehavior.SetNull);

            // Room relationship
            builder.HasOne(t => t.Room)
                .WithMany()
                .HasForeignKey(t => t.RoomId)
                .OnDelete(DeleteBehavior.SetNull);

            // AvailableDay relationship
            builder.HasOne(t => t.AvailableDay)
                .WithMany()
                .HasForeignKey(t => t.AvailableDayId)
                .OnDelete(DeleteBehavior.SetNull);

            // AvailableTimeSlot relationship
            builder.HasOne(t => t.AvailableTimeSlot)
                .WithMany()
                .HasForeignKey(t => t.AvailableTimeSlotId)
                .OnDelete(DeleteBehavior.SetNull);

            // TeacherInterests collection
            builder.HasMany(t => t.TeacherInterests)
                .WithOne(ti => ti.TutoringRequest)
                .HasForeignKey(ti => ti.TutoringRequestId)
                .OnDelete(DeleteBehavior.Cascade);

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
