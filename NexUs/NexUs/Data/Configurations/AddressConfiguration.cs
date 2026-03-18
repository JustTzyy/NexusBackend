using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexUs.Models.Entities;

namespace NexUs.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.StreetBarangay)
                .HasMaxLength(200);

            builder.Property(a => a.Region)
                .HasMaxLength(60);

            builder.Property(a => a.Province)
                .HasMaxLength(60);

            builder.Property(a => a.CityMunicipality)
                .HasMaxLength(60);

            builder.Property(a => a.Postal)
                .HasMaxLength(10);
        }
    }
}
