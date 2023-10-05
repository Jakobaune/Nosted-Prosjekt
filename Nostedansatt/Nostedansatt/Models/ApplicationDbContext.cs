using Microsoft.EntityFrameworkCore;
using Nostedansatt;
using Nostedansatt.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Brukere = Set<Ansatt>();
    }

    public DbSet<Ansatt>? Brukere { get; set; } // Nullable
}