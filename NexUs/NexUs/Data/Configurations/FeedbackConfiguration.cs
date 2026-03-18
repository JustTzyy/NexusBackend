using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedbacks");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Rating)
                .IsRequired();

            builder.Property(f => f.Comment)
                .HasMaxLength(2000);

            builder.HasOne(f => f.TutoringRequest)
                .WithMany()
                .HasForeignKey(f => f.TutoringRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.SessionLog)
                .WithMany()
                .HasForeignKey(f => f.SessionLogId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Customer)
                .WithMany()
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Teacher)
                .WithMany()
                .HasForeignKey(f => f.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            // Audit relationships from BaseEntity
            builder.HasOne(f => f.CreatedByUser)
                .WithMany()
                .HasForeignKey(f => f.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.UpdatedByUser)
                .WithMany()
                .HasForeignKey(f => f.UpdatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
