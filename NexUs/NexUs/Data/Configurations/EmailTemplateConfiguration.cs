using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class EmailTemplateConfiguration : IEntityTypeConfiguration<EmailTemplate>
    {
        public void Configure(EntityTypeBuilder<EmailTemplate> builder)
        {
            builder.ToTable("EmailTemplates");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(150);
            builder.Property(t => t.Subject).IsRequired().HasMaxLength(300);
            builder.Property(t => t.FileName).IsRequired().HasMaxLength(200);
            builder.Property(t => t.Body).HasColumnType("nvarchar(max)");
            builder.Property(t => t.Variables).HasMaxLength(500);
            builder.Property(t => t.Category).HasMaxLength(50);

            builder.HasIndex(t => t.Name).IsUnique();
            builder.HasIndex(t => t.FileName).IsUnique();

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
