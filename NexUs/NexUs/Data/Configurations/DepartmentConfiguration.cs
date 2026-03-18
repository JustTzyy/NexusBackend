using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(d => d.Code)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(d => d.Description)
                .HasMaxLength(500);

            // Audit relationships from BaseEntity
            builder.HasOne(d => d.CreatedByUser)
                .WithMany()
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.UpdatedByUser)
                .WithMany()
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
