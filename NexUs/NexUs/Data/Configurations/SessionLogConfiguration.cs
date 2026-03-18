using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class SessionLogConfiguration : IEntityTypeConfiguration<SessionLog>
    {
        public void Configure(EntityTypeBuilder<SessionLog> builder)
        {
            builder.ToTable("SessionLogs");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Outcome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.AbsentParty)
                .HasMaxLength(20);

            builder.Property(s => s.Notes)
                .HasMaxLength(1000);

            // TutoringRequest relationship
            builder.HasOne(s => s.TutoringRequest)
                .WithMany()
                .HasForeignKey(s => s.TutoringRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            // Audit relationships from BaseEntity
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
