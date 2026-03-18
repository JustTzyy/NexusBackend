using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class CampaignTargetConfiguration : IEntityTypeConfiguration<CampaignTarget>
    {
        public void Configure(EntityTypeBuilder<CampaignTarget> builder)
        {
            builder.ToTable("CampaignTargets");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Email).IsRequired().HasMaxLength(255);
            builder.Property(t => t.FirstName).HasMaxLength(100);
            builder.Property(t => t.LastName).HasMaxLength(100);
            builder.Property(t => t.Status).IsRequired().HasMaxLength(30);

            builder.HasIndex(t => new { t.CampaignId, t.Email }).IsUnique();
            builder.HasIndex(t => t.CampaignId);
            builder.HasIndex(t => t.Status);

            builder.HasOne(t => t.Campaign)
                .WithMany(c => c.CampaignTargets)
                .HasForeignKey(t => t.CampaignId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
