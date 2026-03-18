using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.ToTable("Buildings");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Manager relationship
            builder.HasOne(b => b.Manager)
                .WithMany()
                .HasForeignKey(b => b.ManagedBy)
                .OnDelete(DeleteBehavior.SetNull);

            // Address relationship
            builder.HasOne(b => b.Address)
                .WithMany()
                .HasForeignKey(b => b.AddressId)
                .OnDelete(DeleteBehavior.SetNull);

            // Audit relationships from BaseEntity
            builder.HasOne(b => b.CreatedByUser)
                .WithMany()
                .HasForeignKey(b => b.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.UpdatedByUser)
                .WithMany()
                .HasForeignKey(b => b.UpdatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
