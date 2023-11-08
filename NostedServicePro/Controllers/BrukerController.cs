using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NostedServicePro.Data;
using NostedServicePro.Models;
using System.Linq;
using System.Threading.Tasks;

[Authorize(Roles = "Admin")]
public class BrukerController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ILogger<BrukerController> _logger;
    private readonly ServiceProDbContex _context; // Legg til dette hvis nødvendig

    public BrukerController(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        ILogger<BrukerController> logger,
        ServiceProDbContex context) // Legg til dette hvis nødvendig
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _logger = logger;
        _context = context; // Legg til dette hvis nødvendig
    }

    public async Task<IActionResult> VisAlleBrukere()
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

        return View(brukerMedRollerList);
    }

    [HttpGet]
    public async Task<IActionResult> RedigerBruker(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound();
        }

        var userRoles = await _userManager.GetRolesAsync(user);
        var allRoles = await _roleManager.Roles.Select(role => role.Name).ToListAsync();

        var model = new EditUserViewModel
        {
            UserId = userId,
            UserName = user.UserName,
            Email = user.Email,
            CurrentRoles = userRoles.ToList(),
            SelectedRoles = userRoles.ToList(), // Sett opprinnelige roller som valgte roller
            AllRoles = allRoles.ToList()
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RedigerBruker(EditUserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                return NotFound();
            }

            user.UserName = model.UserName;
            user.Email = model.Email;

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        // Fjern eksisterende roller og legg til de nye basert på brukerens valg
                        var existingRoles = await _userManager.GetRolesAsync(user);
                        await _userManager.RemoveFromRolesAsync(user, existingRoles);
                        await _userManager.AddToRolesAsync(user, model.SelectedRoles);

                        TempData["Message"] = "Brukeren er oppdatert vellykket!";

                        await transaction.CommitAsync();

                        return RedirectToAction("VisAlleBrukere");
                    }

                    AddErrors(result);
                    TempData["ErrorMessage"] = "Feil ved oppdatering av brukeren. Vennligst prøv igjen.";
                }
                catch (Exception ex)
                {
                    // Rull tilbake transaksjonen hvis det oppstår en feil
                    await transaction.RollbackAsync();
                    _logger.LogError($"Feil ved oppdatering av bruker: {ex.Message}");
                    TempData["ErrorMessage"] = "En feil oppstod under oppdatering av brukeren. Vennligst prøv igjen.";
                }
            }
        }

        // Gjenta visning hvis modellvalidering mislyktes
        var allRoles = await _roleManager.Roles.Select(role => role.Name).ToListAsync();
        model.AllRoles = allRoles;

        return View(model);
    }





    [HttpGet]
    public async Task<IActionResult> SlettBruker(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    [HttpPost, ActionName("SlettBruker")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> BekreftSlettBruker(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound();
        }

        var result = await _userManager.DeleteAsync(user);

        if (result.Succeeded)
        {
            TempData["Message"] = "Brukeren er slettet vellykket!";
            _logger.LogInformation($"Brukeren {user.UserName} ble slettet.");

            return RedirectToAction("VisAlleBrukere");
        }

        AddErrors(result);
        _logger.LogError($"Feil ved sletting av bruker {user.UserName}");

        return View("SlettBruker", user);
    }

    private void AddErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
    }
}
