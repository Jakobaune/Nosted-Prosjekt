// I ApplicationDbContext.cs

namespace Nostedansatt.Models
{

    // I Bruker.cs
    public class Ansatt
    {
        public string? BrukerNavn { get; set; }
        public string? EpostAdresse { get; set; }
        public string? Rolle { get; set; } // Endret fra nullable
        public string? Passord { get; set; }
    }
}