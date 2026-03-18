using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class AvailableDayConfiguration : IEntityTypeConfiguration<AvailableDay>
    {
        public void Configure(EntityTypeBuilder<AvailableDay> builder)
        {
            builder.ToTable("AvailableDays");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.DayName)
                .IsRequired()
                .HasMaxLength(20);

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
