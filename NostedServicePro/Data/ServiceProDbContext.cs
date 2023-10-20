using Loginnosted.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Loginnosted.Data
{
    public class ServiceProDbContex : DbContext
    {
        public ServiceProDbContex(DbContextOptions<ServiceProDbContex> options) : base(options)
        {
        }

        public DbSet<Bruker> Brukere { get; set; }
        public DbSet<ServiceOrdre> service { get; set; }
        public DbSet<Sjekkliste> Sjekkliste { get; set; } // Legg til Sjekkliste DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Legg til eventuelle konfigurasjoner for modellene her
        }
    }
}

