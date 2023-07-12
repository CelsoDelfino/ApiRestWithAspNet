using Microsoft.EntityFrameworkCore;
using RestWithAspNet.Model;

namespace RestWithAspNet.Data
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {}
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
