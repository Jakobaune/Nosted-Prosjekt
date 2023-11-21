using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NostedServicePro.Data;

public class ServiceProDbContex : IdentityDbContext<IdentityUser>
{
    public ServiceProDbContex(DbContextOptions<ServiceProDbContex> options) : base(options)
    {
    }

    public DbSet<ServiceOrdre> service { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}