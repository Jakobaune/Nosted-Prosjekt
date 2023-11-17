using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NostedServicePro.Models;
using NostedServicePro.Models.Account;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Authorize(Roles = "Admin")]
public class BrukerController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public BrukerController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
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

        var viewName = "VisAlleBrukere"; // Sett ViewName manuelt
        return View(viewName, brukerMedRollerList);
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
        var model = new EditUserViewModel { UserId = userId, UserName = user.UserName, Email = user.Email, CurrentRoles = userRoles.ToList() };

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

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                // Fjern eksisterende roller og legg til de nye basert på brukerens valg
                var existingRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, existingRoles);
                await _userManager.AddToRolesAsync(user, model.SelectedRoles);

                TempData["Message"] = "Brukeren er oppdatert vellykket!";

                return RedirectToAction("VisAlleBrukere");
            }

            AddErrors(result);
        }

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
            return RedirectToAction("VisAlleBrukere");
        }

        AddErrors(result);

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
