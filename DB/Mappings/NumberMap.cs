using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB.Mappings
{
    public class NumberMap : IEntityTypeConfiguration<Number>
    {
        public void Configure(EntityTypeBuilder<Number> builder)
        {
            builder.ToTable("Number");
            builder.HasKey(c => c.idNumber);

            builder.Property(c => c.idNumber).HasColumnName("idNumber").ValueGeneratedOnAdd();
            builder.Property(c => c.Identification).HasColumnName("Identification");
            builder.Property(c => c.PhoneNumber).HasColumnName("PhoneNumber");

            //builder.HasOne(c => c.Customer).WithMany(p => p.Numbers);
        }
    }
}
