using DB.Mappings;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersRegistration.Models
{
    public class Context : DbContext
    {
        public Context () { }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Number> Numbers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Data Source=LAPTOP-Q2AMV2TA\SQLEXPRESS;Initial Catalog=BANCO;Integrated Security=True");
        }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new NumberMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new SocialMediaMap());
        }
    }
}