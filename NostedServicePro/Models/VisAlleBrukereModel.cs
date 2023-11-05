using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;



namespace NostedServicePro.Models
{
    public class VisAlleBrukereModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public VisAlleBrukereModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public List<BrukerMedRoller> BrukereMedRoller { get; set; }

        public string Title { get; set; } = "VisAlleBrukere"; // Setter en standard tittel

        public async Task OnGetAsync()
        {
            // Hent alle brukere
            var brukere = await _userManager.Users.ToListAsync();

            // Hent roller for hver bruker
            BrukereMedRoller = brukere.Select(user => new BrukerMedRoller
            {
                Bruker = user,
                Roller = _userManager.GetRolesAsync(user).Result.ToList()
            }).ToList();
        }
    }

    public class BrukerMedRoller
    {
        public IdentityUser Bruker { get; set; }
        public List<string> Roller { get; set; }
    }
}