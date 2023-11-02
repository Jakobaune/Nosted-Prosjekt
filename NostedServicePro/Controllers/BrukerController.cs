using Microsoft.AspNetCore.Mvc;
using Loginnosted.Data;
using Loginnosted.Models;
using System;
using Microsoft.AspNetCore.Authorization;

[Authorize]
public class BrukerController : Controller
{
    private readonly ServiceProDbContex _dbContext;

    public BrukerController(ServiceProDbContex dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult VisAlleBrukere()
    {
        // Hent TempData-melding hvis den finnes
        var brukerNavn = TempData["BrukerNavn"] as string;

        var brukere = _dbContext.Brukere.ToList(); // Hent alle brukere fra databasen

        // Legg til brukerNavn i ViewData
        ViewData["BrukerNavn"] = brukerNavn;

        return View("VisAlleBrukere", brukere);
    }



    public IActionResult Registrering()
    {
        return View(); // Vis skjemaet
    }

    //Metode osm henter frem brukere fra DB)
    public IActionResult RedigerBruker(int id)
    {
        var bruker = _dbContext.Brukere.Find(id);
        return View(bruker);
    }


    public IActionResult SlettBruker(int id)
    {
        var bruker = _dbContext.Brukere.Find(id); // Finn brukeren basert på ID

        if (bruker != null)
        {
            _dbContext.Brukere.Remove(bruker); //Fletter brukeren basert på ID
            _dbContext.SaveChanges();
        }

        return RedirectToAction("VisAlleBrukere"); //Returnerer til vis alle brukere view
    }




    //Metode for å redigere brukere
    [HttpPost]
    [ValidateAntiForgeryToken]
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

                // Legg til TempData-melding
                TempData["BrukerNavn"] = eksisterendeBruker.BrukerNavn;

                return RedirectToAction("VisAlleBrukere");
            }
            catch (Exception ex)
            {
                // Håndter feil, for eksempel logging 
                TempData["Feilmelding"] = "Feil ved lagring av endringer.";
            }
        }

        // Hvis skjemaet ikke er gyldig, vis det samme skjemaet igjen med feilmeldinger
        return View(bruker);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult LagreData(Bruker bruker)
    {
        if (ModelState.IsValid)
        {
            try
            {
                // Lagre dataene i databasen
                _dbContext.Brukere.Add(bruker);
                _dbContext.SaveChanges();

                // Legg til en TempData-melding
                TempData["BrukerNavn"] = bruker.BrukerNavn;
            }
            catch (Exception ex)
            {
                // Håndter feil, for eksempel logg feilen
                TempData["Feilmelding"] = "Feil ved lagring av data.";
            }
        }

        // Omdiriger til "VisAlleBrukere"
        return RedirectToAction("VisAlleBrukere");
    }
}
