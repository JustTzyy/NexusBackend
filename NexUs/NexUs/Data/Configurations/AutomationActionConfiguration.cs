using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class AutomationActionConfiguration : IEntityTypeConfiguration<AutomationAction>
    {
        public void Configure(EntityTypeBuilder<AutomationAction> builder)
        {
            builder.ToTable("AutomationActions");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.ActionType).IsRequired().HasMaxLength(50);

            builder.HasOne(a => a.AutomationRule)
                .WithMany(r => r.Actions)
                .HasForeignKey(a => a.AutomationRuleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.EmailTemplate)
                .WithMany(t => t.AutomationActions)
                .HasForeignKey(a => a.EmailTemplateId)
                .OnDelete(DeleteBehavior.SetNull);

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
