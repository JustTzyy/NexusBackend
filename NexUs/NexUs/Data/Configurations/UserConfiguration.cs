using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.MiddleName)
                .HasMaxLength(100);

            builder.Property(u => u.Suffix)
                .HasMaxLength(10);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Phone)
                .HasMaxLength(20);

            builder.Property(u => u.Gender)
                .HasMaxLength(20);

            builder.Property(u => u.Nationality)
                .HasMaxLength(100);

            // Soft delete query filter
            builder.HasQueryFilter(u => u.DeletedAt == null);

            // Relationships
            builder.HasOne(u => u.Address)
                .WithMany(a => a.Users)
                .HasForeignKey(u => u.AddressId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(u => u.CreatedByUser)
                .WithMany()
                .HasForeignKey(u => u.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(u => u.UpdatedByUser)
                .WithMany()
                .HasForeignKey(u => u.UpdatedBy)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
