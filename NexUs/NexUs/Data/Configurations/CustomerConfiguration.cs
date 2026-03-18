using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Notes).HasMaxLength(1000);

            builder.HasIndex(c => c.UserId).IsUnique();
            builder.HasIndex(c => c.LeadId);

            builder.HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Lead)
                .WithOne(l => l.Customer)
                .HasForeignKey<Customer>(c => c.LeadId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(c => c.FirstTutoringRequest)
                .WithMany()
                .HasForeignKey(c => c.FirstTutoringRequestId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(c => c.CreatedByUser)
                .WithMany()
                .HasForeignKey(c => c.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.UpdatedByUser)
                .WithMany()
                .HasForeignKey(c => c.UpdatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
