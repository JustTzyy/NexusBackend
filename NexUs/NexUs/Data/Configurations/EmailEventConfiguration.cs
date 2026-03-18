using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class EmailEventConfiguration : IEntityTypeConfiguration<EmailEvent>
    {
        public void Configure(EntityTypeBuilder<EmailEvent> builder)
        {
            builder.ToTable("EmailEvents");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.EventType).IsRequired().HasMaxLength(30);
            builder.Property(e => e.Notes).HasMaxLength(500);

            builder.HasIndex(e => e.EmailMessageId);
            builder.HasIndex(e => e.EventType);

            builder.HasOne(e => e.EmailMessage)
                .WithMany(m => m.EmailEvents)
                .HasForeignKey(e => e.EmailMessageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
