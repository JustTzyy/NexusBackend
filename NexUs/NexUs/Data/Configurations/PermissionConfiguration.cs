using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Module)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(p => new { p.Name, p.Module })
                .IsUnique();

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            // Soft delete query filter
            builder.HasQueryFilter(p => p.DeletedAt == null);

            // Audit relationships
            builder.HasOne(p => p.CreatedByUser)
                .WithMany()
                .HasForeignKey(p => p.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.UpdatedByUser)
                .WithMany()
                .HasForeignKey(p => p.UpdatedBy)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
