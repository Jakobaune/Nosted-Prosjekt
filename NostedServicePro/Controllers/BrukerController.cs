using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NostedServicePro.Models;

// Kontroller for brukeradministrasjon som krever administratorrolle for tilgang
[Authorize(Roles = "Admin")]
public class BrukerController : Controller
{
    private readonly ILogger<BrukerController> _logger;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;

    // Konstruktør som injiserer nødvendige tjenester og avhengigheter
    public BrukerController(UserManager<IdentityUser> userManager, ILogger<BrukerController> logger,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _logger = logger;
        _roleManager = roleManager;
    }

    // Aksjonsmetode for å vise alle brukere
    public async Task<IActionResult> VisAlleBrukere()
    {
        try
        {
            var brukere = _userManager.Users.ToList();
            var brukerMedRollerList = new List<BrukerMedRollerViewModel>();

            foreach (var bruker in brukere)
            {
                var roller = await _userManager.GetRolesAsync(bruker);
                var brukerMedRoller = new BrukerMedRollerViewModel
                {
                    UserId = bruker.Id,
                    UserName = bruker.UserName,
                    Email = bruker.Email,
                    Roller = roller.ToList()
                };

                brukerMedRollerList.Add(brukerMedRoller);
            }

            var viewName = "VisAlleBrukere"; // Setter ViewName manuelt
            return View(viewName, brukerMedRollerList);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Feil under VisAlleBrukere-metoden.");
            throw;
        }
    }

    // Aksjonsmetode for å vise redigeringsvisning for en bruker
    [HttpGet]
    public async Task<IActionResult> RedigerBruker(string userId)
    {
        if (string.IsNullOrEmpty(userId)) return NotFound();

        var bruker = await _userManager.FindByIdAsync(userId);

        if (bruker == null) return NotFound();

        var roller = await _userManager.GetRolesAsync(bruker);
        var alleRoller = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

        var brukerMedRoller = new BrukerMedRollerViewModel
        {
            UserId = bruker.Id,
            UserName = bruker.UserName,
            Email = bruker.Email,
            Roller = roller.ToList(),
            AlleRoller = alleRoller
        };

        return View(brukerMedRoller);
    }

    // Aksjonsmetode for å lagre endringer i en bruker
    [HttpPost]
    public async Task<IActionResult> LagreRedigering(BrukerMedRollerViewModel model)
    {
        var bruker = await _userManager.FindByIdAsync(model.UserId);

        if (bruker == null) return NotFound();

        // Logg nåværende roller før oppdatering
        var nåværendeRollerFør = await _userManager.GetRolesAsync(bruker);
        _logger.LogInformation($"Nåværende roller før oppdatering: {string.Join(", ", nåværendeRollerFør)}");

        // Oppdater roller
        foreach (var rolle in model.Roller)
            if (!await IsUserInRoleAsync(bruker, rolle))
                await _userManager.AddToRoleAsync(bruker, rolle);

        var nåværendeRollerEtter = await _userManager.GetRolesAsync(bruker);
        _logger.LogInformation($"Nåværende roller etter oppdatering: {string.Join(", ", nåværendeRollerEtter)}");

        // Fjern roller som er fjernet i brukerens visning
        var fjernedeRoller = nåværendeRollerFør.Except(model.Roller);

        foreach (var rolle in fjernedeRoller) await _userManager.RemoveFromRoleAsync(bruker, rolle);

        // Logg nåværende roller etter fjerning
        var nåværendeRollerEtterFjerning = await _userManager.GetRolesAsync(bruker);
        _logger.LogInformation($"Nåværende roller etter fjerning: {string.Join(", ", nåværendeRollerEtterFjerning)}");

        // Oppdater brukerinformasjon
        bruker.UserName = model.UserName;
        bruker.Email = model.Email;

        // Lagre endringer i databasen
        var result = await _userManager.UpdateAsync(bruker);

        if (!result.Succeeded)
        {
            _logger.LogError($"Feil ved oppdatering av bruker: {string.Join(", ", result.Errors)}");
            return View("RedigerBruker"); // Vis feilsiden eller håndter feilen på en annen måte
        }

        // Logg suksess
        _logger.LogInformation("Brukeroppdatering vellykket!");
        TempData["Message"] = "Brukeren er endret!";

        // Endre returverdien til å omdirigere til "VisAlleBrukere"
        return RedirectToAction("VisAlleBrukere");
    }

    // Privat metode for å sjekke om en bruker har en bestemt rolle
    private async Task<bool> IsUserInRoleAsync(IdentityUser user, string role)
    {
        return await _userManager.IsInRoleAsync(user, role);
    }

    // Aksjonsmetode for å vise slettevisning for en bruker
    [HttpGet]
    public async Task<IActionResult> SlettBruker(string userId)
    {
        if (string.IsNullOrEmpty(userId)) return NotFound();

        var bruker = await _userManager.FindByIdAsync(userId);
        if (bruker == null) return NotFound();

        var brukerMedRollerViewModel = new BrukerMedRollerViewModel
        {
            UserId = bruker.Id,
            UserName = bruker.UserName,
            Email = bruker.Email,
            Roller = await _userManager.GetRolesAsync(bruker)
        };

        return View(brukerMedRollerViewModel);
    }

    // Aksjonsmetode for å bekrefte sletting av en bruker
    [HttpPost]
    public async Task<IActionResult> BekreftSlettBruker(string userId)
    {
        if (string.IsNullOrEmpty(userId)) return NotFound();

        var bruker = await _userManager.FindByIdAsync(userId);
        if (bruker == null) return NotFound();

        var result = await _userManager.DeleteAsync(bruker);
        if (result.Succeeded)
        {
            TempData["Message"] = "Brukeren er slettet vellykket!";
            return RedirectToAction("VisAlleBrukere");
        }

        TempData["ErrorMessage"] = "Feil ved sletting av bruker.";
        return RedirectToAction("VisAlleBrukere");
    }
}
