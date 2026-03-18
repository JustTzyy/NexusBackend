using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class UserCredentialConfiguration : IEntityTypeConfiguration<UserCredential>
    {
        public void Configure(EntityTypeBuilder<UserCredential> builder)
        {
            builder.ToTable("UserCredentials");

            builder.HasKey(uc => uc.Id);

            builder.HasIndex(uc => uc.UserId)
                .IsUnique();

            builder.Property(uc => uc.PasswordHash)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(uc => uc.PasswordSalt)
                .HasMaxLength(500);

            builder.Property(uc => uc.DefaultPassword)
                .HasMaxLength(500);

            builder.HasOne(uc => uc.User)
                .WithOne()
                .HasForeignKey<UserCredential>(uc => uc.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
