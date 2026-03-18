using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class AvailableTimeSlotConfiguration : IEntityTypeConfiguration<AvailableTimeSlot>
    {
        public void Configure(EntityTypeBuilder<AvailableTimeSlot> builder)
        {
            builder.ToTable("AvailableTimeSlots");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Label)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.StartTime)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(a => a.EndTime)
                .IsRequired()
                .HasMaxLength(10);

            // Audit relationships from BaseEntity
            builder.HasOne(a => a.CreatedByUser)
                .WithMany()
                .HasForeignKey(a => a.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.UpdatedByUser)
                .WithMany()
                .HasForeignKey(a => a.UpdatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
