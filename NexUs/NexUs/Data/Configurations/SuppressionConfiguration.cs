using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class SuppressionConfiguration : IEntityTypeConfiguration<Suppression>
    {
        public void Configure(EntityTypeBuilder<Suppression> builder)
        {
            builder.ToTable("Suppressions");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Email).IsRequired().HasMaxLength(255);
            builder.Property(s => s.Reason).IsRequired().HasMaxLength(30);
            builder.Property(s => s.Source).IsRequired().HasMaxLength(20);
            builder.Property(s => s.Notes).HasMaxLength(500);

            builder.HasIndex(s => s.Email).IsUnique();

            builder.HasOne(s => s.CreatedByUser)
                .WithMany()
                .HasForeignKey(s => s.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.UpdatedByUser)
                .WithMany()
                .HasForeignKey(s => s.UpdatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
