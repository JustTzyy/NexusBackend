using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.ToTable("Campaigns");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Subject).IsRequired().HasMaxLength(300);
            builder.Property(c => c.Status).IsRequired().HasMaxLength(30);

            builder.HasIndex(c => c.Status);
            builder.HasIndex(c => c.ScheduledAt);

            builder.HasOne(c => c.EmailTemplate)
                .WithMany(t => t.Campaigns)
                .HasForeignKey(c => c.EmailTemplateId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(c => c.Segment)
                .WithMany(s => s.Campaigns)
                .HasForeignKey(c => c.SegmentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(c => c.CreatedByUser)
                .WithMany()
                .HasForeignKey(c => c.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.UpdatedByUser)
                .WithMany()
                .HasForeignKey(c => c.UpdatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
