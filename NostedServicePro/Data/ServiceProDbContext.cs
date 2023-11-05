using NostedServicePro.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NostedServicePro.Models.Account;

namespace NostedServicePro.Data
{
    public class ServiceProDbContex : IdentityDbContext<IdentityUser>
    {
        public ServiceProDbContex(DbContextOptions<ServiceProDbContex> options)
            : base(options)
        {
        }
        public DbSet<Bruker> Brukere { get; set; }
        public DbSet<ServiceOrdre> service { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
