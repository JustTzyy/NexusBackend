using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class AuthActivityLogConfiguration : IEntityTypeConfiguration<AuthActivityLog>
    {
        public void Configure(EntityTypeBuilder<AuthActivityLog> builder)
        {
            builder.ToTable("auth_activity_logs");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Action)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(a => a.IpAddress)
                .HasMaxLength(45);

            builder.Property(a => a.Device)
                .HasMaxLength(255);

            builder.Property(a => a.Location)
                .HasMaxLength(255);

            builder.HasOne(a => a.User)
                .WithMany(u => u.AuthActivityLogs)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
