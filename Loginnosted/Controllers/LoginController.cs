using Microsoft.AspNetCore.Mvc;
using Loginnosted.Data;
using Loginnosted.Models;
using System;

public class LoginController : Controller
{
    private readonly LoginnostedDbContext _dbContext;

    public LoginController(LoginnostedDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult VisAlleBrukere()
    {
        var brukere = _dbContext.Brukere.ToList(); // Hent alle brukere fra databasen
        return View("VisAlleBrukere", brukere);
    }


    public IActionResult Registrering()
    {
        return View(); // Vis skjemaet
    }


    public IActionResult SlettBruker(int id)
    {
        var bruker = _dbContext.Brukere.Find(id); // Finn brukeren basert på ID

        if (bruker != null)
        {
            _dbContext.Brukere.Remove(bruker);
            _dbContext.SaveChanges();
        }

        return RedirectToAction("VisAlleBrukere");
    }

    public IActionResult RedigerBruker(int id)
    {
        var bruker = _dbContext.Brukere.Find(id);
        return View(bruker);
    }

    [HttpPost]
    [HttpPost]
    public IActionResult RedigerBruker(Bruker bruker)
    {
        if (ModelState.IsValid)
        {
            try
            {
                // Hent den eksisterende brukeren fra databasen
                var eksisterendeBruker = _dbContext.Brukere.Find(bruker.BrukerId);

                // Oppdater feltene som ikke er passord
                eksisterendeBruker.BrukerNavn = bruker.BrukerNavn;
                eksisterendeBruker.Epostadresse = bruker.Epostadresse;
                eksisterendeBruker.Rolle = bruker.Rolle;

                // Sjekk om passordet er angitt, og oppdater det hvis det er tilfelle
                if (!string.IsNullOrEmpty(bruker.Passord))
                {
                    // Hash passordet før lagring
                    eksisterendeBruker.Passord = BCrypt.Net.BCrypt.HashPassword(bruker.Passord);
                }

                // Lagre endringene
                _dbContext.SaveChanges();

                return RedirectToAction("VisAlleBrukere");
            }
            catch (Exception ex)
            {
                // Håndter feil, for eksempel logg feilen
                return Content("Feil ved lagring av endringer.");
            }
        }

        // Hvis skjemaet ikke er gyldig, vis det samme skjemaet igjen med feilmeldinger
        return View(bruker);
    }




    [HttpPost]
    public IActionResult LagreData(Bruker bruker)
    {
        if (ModelState.IsValid)
        {
            try
            {
                // Lagre dataene i databasen
                _dbContext.Brukere.Add(bruker);
                _dbContext.SaveChanges();

                // Ingen omdirigering, du kan håndtere det på en annen måte om nødvendig
                return Content("Data lagret vellykket!");
            }
            catch (Exception ex)
            {
                // Håndter feil, for eksempel logg feilen
                return Content("Feil ved lagring av data.");
            }
        }

        // Hvis skjemaet ikke er gyldig, vis det samme skjemaet igjen med feilmeldinger
        return View();
    }

}