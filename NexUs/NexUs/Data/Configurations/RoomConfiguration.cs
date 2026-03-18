using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Building relationship
            builder.HasOne(r => r.Building)
                .WithMany()
                .HasForeignKey(r => r.BuildingId)
                .OnDelete(DeleteBehavior.Restrict);

            // Audit relationships from BaseEntity
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
