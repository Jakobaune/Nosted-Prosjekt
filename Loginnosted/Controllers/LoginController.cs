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

    public IActionResult Index()
    {
        return View(); // Vis skjemaet
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
