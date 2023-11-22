using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Abstractions;

namespace NostedServicePro.Data
{
    // Databasekontekst som utvider IdentityDbContext for brukeradministrasjon
    public class ServiceProDbContex : IdentityDbContext<IdentityUser>
    {
        // Konstruktør som tar imot DbContextOptions og sender dem videre til basisklassen
        public ServiceProDbContex(DbContextOptions<ServiceProDbContex> options) : base(options)
        {
        }

        // DbSet for ServiceOrdre-entiteten som representerer serviceordre i databasen
        public DbSet<ServiceOrdre> service { get; set; }

        // Metode som kan brukes til å tilpasse konfigurasjonen av modellene i databasen
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
