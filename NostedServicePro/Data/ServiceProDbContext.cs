using Loginnosted.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Loginnosted.Models.Account;

namespace Loginnosted.Data
{
    public class ServiceProDbContex : IdentityDbContext<IdentityUser>
    {
        public ServiceProDbContex(DbContextOptions<ServiceProDbContex> options)
            : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Bruker> Brukere { get; set; }
        public DbSet<ServiceOrdre> service { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>().ToTable("aspnetusers");

        }
    }
}
