using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NostedServicePro.Data;
using NostedServicePro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BrukerController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public BrukerController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public IActionResult VisAlleBrukere()
    {
        // Hent TempData-melding hvis den finnes
        var brukerNavn = TempData["BrukerNavn"] as string;

        // Hent alle brukere fra "AspNetUsers" tabellen
        var brukere = _userManager.Users.ToList();

        // Legg til brukerNavn i ViewData
        ViewData["BrukerNavn"] = brukerNavn;

        return View("VisAlleBrukere", brukere);
    }

}
