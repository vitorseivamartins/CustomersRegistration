using CustomersRegistration.Models;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class MigrationsContext : IDbContextFactory<Context>
    {
        private const string CONNECTIONSTRING = @"Data Source=LAPTOP-Q2AMV2TA\SQLEXPRESS;Initial Catalog=BANCO;Integrated Security=True";
        public Context CreateDbContext()
        {
            var construtor = new DbContextOptionsBuilder<Context>();
            construtor.UseSqlServer(CONNECTIONSTRING);
            return new Context(construtor.Options);
        }
}
}
