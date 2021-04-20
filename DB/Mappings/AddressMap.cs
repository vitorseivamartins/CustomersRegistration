using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(c => c.idAddress);

            builder.Property(c => c.idAddress).HasColumnName("idAddress").ValueGeneratedOnAdd();
            builder.Property(c => c.Identification).HasColumnName("Identification");
            builder.Property(c => c.StreetAddress).HasColumnName("StreetAddress");

            //builder.HasOne(c => c.Customer).WithMany(p => p.Addresses);
        }
    }
}
