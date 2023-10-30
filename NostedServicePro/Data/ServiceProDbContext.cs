using NostedServicePro.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace NostedServicePro.Data
{
    public class ServiceProDbContex : DbContext
    {
        public ServiceProDbContex(DbContextOptions<ServiceProDbContex> options) : base(options)
        {
        }

        public DbSet<Bruker> Brukere { get; set; }
        public DbSet<ServiceOrdre> service { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Legg til eventuelle konfigurasjoner for modellene her
        }
    }
}

