using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class EmailMessageConfiguration : IEntityTypeConfiguration<EmailMessage>
    {
        public void Configure(EntityTypeBuilder<EmailMessage> builder)
        {
            builder.ToTable("EmailMessages");
            builder.HasKey(m => m.Id);

            builder.Property(m => m.RecipientEmail).IsRequired().HasMaxLength(255);
            builder.Property(m => m.RecipientName).HasMaxLength(200);
            builder.Property(m => m.Subject).IsRequired().HasMaxLength(300);
            builder.Property(m => m.Body).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(m => m.VariablesJson).HasColumnType("nvarchar(max)");
            builder.Property(m => m.Status).IsRequired().HasMaxLength(30);
            builder.Property(m => m.ErrorMessage).HasMaxLength(1000);

            builder.HasIndex(m => m.Status);
            builder.HasIndex(m => m.QueuedAt);
            builder.HasIndex(m => m.RecipientEmail);
            builder.HasIndex(m => m.CampaignId);

            builder.HasOne(m => m.Campaign)
                .WithMany(c => c.EmailMessages)
                .HasForeignKey(m => m.CampaignId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(m => m.AutomationRule)
                .WithMany(r => r.EmailMessages)
                .HasForeignKey(m => m.AutomationRuleId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(m => m.EmailTemplate)
                .WithMany(t => t.EmailMessages)
                .HasForeignKey(m => m.EmailTemplateId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(m => m.RecipientUser)
                .WithMany()
                .HasForeignKey(m => m.RecipientUserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
