using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class TutoringRequestStatusHistoryConfiguration : IEntityTypeConfiguration<TutoringRequestStatusHistory>
    {
        public void Configure(EntityTypeBuilder<TutoringRequestStatusHistory> builder)
        {
            builder.ToTable("TutoringRequestStatusHistories");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.FromStatus)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(h => h.ToStatus)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(h => h.ChangedByRole)
                .IsRequired()
                .HasMaxLength(20);

            // TutoringRequest relationship
            builder.HasOne(h => h.TutoringRequest)
                .WithMany()
                .HasForeignKey(h => h.TutoringRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            // Audit relationships from BaseEntity
            builder.HasOne(h => h.CreatedByUser)
                .WithMany()
                .HasForeignKey(h => h.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(h => h.UpdatedByUser)
                .WithMany()
                .HasForeignKey(h => h.UpdatedBy)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
