using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace NostedServicePro.Models
{
    public class VisAlleBrukereModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        // Konstruktør som injiserer UserManager for å håndtere brukeroperasjoner
        public VisAlleBrukereModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        // Liste som inneholder brukere med tilhørende roller
        public List<BrukerMedRoller> BrukereMedRoller { get; set; }

        // Standard tittel for siden
        public string Title { get; set; } = "VisAlleBrukere";

        // Metode som kalles når GET-forespørselen utføres på siden
        public async Task OnGetAsync()
        {
            // Hent alle brukere fra databasen
            var brukere = await _userManager.Users.ToListAsync();

            // Opprett en liste av BrukerMedRoller ved å hente roller for hver bruker
            BrukereMedRoller = brukere.Select(user => new BrukerMedRoller
            {
                Bruker = user,
                Roller = _userManager.GetRolesAsync(user).Result.ToList()
            }).ToList();
        }
    }

    // Modellklasse som representerer en bruker med tilhørende roller
    public class BrukerMedRoller
    {
        public IdentityUser Bruker { get; set; }
        public List<string> Roller { get; set; }
    }
}
