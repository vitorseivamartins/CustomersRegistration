using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {          
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(c => c.idCustomer);

            builder.Property(c => c.idCustomer).HasColumnName("idCustomer").ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasColumnName("Name");
            builder.Property(c => c.BirthdayDate).HasColumnName("BirthdayDate");
            builder.Property(c => c.CpfNumber).HasColumnName("CpfNumber");
            builder.Property(c => c.RgNumber).HasColumnName("RgNumber");

            //builder.HasMany(t => t.Numbers).WithOne(t.);
            //builder.HasMany(t => t.Addresses);
            //builder.HasMany(t => t.SocialMedias);

        }
    }
}
