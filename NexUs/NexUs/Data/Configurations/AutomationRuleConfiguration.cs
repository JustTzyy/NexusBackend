using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class AutomationRuleConfiguration : IEntityTypeConfiguration<AutomationRule>
    {
        public void Configure(EntityTypeBuilder<AutomationRule> builder)
        {
            builder.ToTable("AutomationRules");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name).IsRequired().HasMaxLength(200);
            builder.Property(r => r.TriggerType).IsRequired().HasMaxLength(60);
            builder.Property(r => r.ConditionsJson).HasColumnType("nvarchar(max)");

            builder.HasIndex(r => r.TriggerType);
            builder.HasIndex(r => r.IsActive);

            builder.HasOne(r => r.CreatedByUser)
                .WithMany()
                .HasForeignKey(r => r.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.UpdatedByUser)
                .WithMany()
                .HasForeignKey(r => r.UpdatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
