using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class SegmentConfiguration : IEntityTypeConfiguration<Segment>
    {
        public void Configure(EntityTypeBuilder<Segment> builder)
        {
            builder.ToTable("Segments");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name).IsRequired().HasMaxLength(150);
            builder.Property(s => s.Description).HasMaxLength(500);
            builder.Property(s => s.Type).IsRequired().HasMaxLength(20);
            builder.Property(s => s.RulesJson).HasColumnType("nvarchar(max)");

            builder.HasIndex(s => s.Name).IsUnique();

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
