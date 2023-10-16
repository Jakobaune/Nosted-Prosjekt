using Loginnosted.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Loginnosted.Data
{
    public class LoginnostedDbContext : DbContext
    {
        public LoginnostedDbContext(DbContextOptions<LoginnostedDbContext> options) : base(options)
        {
        }

        public DbSet<Bruker> Brukere { get; set; }

        public DbSet<ServiceOrdre> service { get; set; }

        public DbSet<SjekklisteElement> SjekklisteElement { get; set; }

    }
}
