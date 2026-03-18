using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class LeadConfiguration : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.ToTable("Leads");
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Email).IsRequired().HasMaxLength(255);
            builder.Property(l => l.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(l => l.LastName).IsRequired().HasMaxLength(100);
            builder.Property(l => l.Phone).HasMaxLength(20);
            builder.Property(l => l.Source).IsRequired().HasMaxLength(50);
            builder.Property(l => l.Status).IsRequired().HasMaxLength(30);
            builder.Property(l => l.Notes).HasMaxLength(1000);

            builder.HasIndex(l => l.Email).IsUnique();
            builder.HasIndex(l => l.Status);
            builder.HasIndex(l => l.UserId);

            builder.HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(l => l.CreatedByUser)
                .WithMany()
                .HasForeignKey(l => l.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.UpdatedByUser)
                .WithMany()
                .HasForeignKey(l => l.UpdatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
