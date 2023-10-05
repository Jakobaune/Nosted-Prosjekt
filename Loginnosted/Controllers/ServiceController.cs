using Loginnosted.Data;
using Loginnosted.Models;
using Microsoft.AspNetCore.Mvc;
using System;

public class ServiceController : Controller
{
    private readonly LoginnostedDbContext _dbContext;

    public ServiceController(LoginnostedDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        return View(); // Vis skjemaet for å bestille service
    }

    [HttpPost]
    public IActionResult Index(ServiceOrdre serviceOrdre)
    {
        if (ModelState.IsValid)
        {
            try
            {
                // Lagre dataene i databasen
                _dbContext.service.Add(serviceOrdre);
                _dbContext.SaveChanges();

                // Gir bekreftelse
                return Content("Data lagret vellykket!");
            }
            catch (Exception ex)
            {
                // Håndter feil, for eksempel logg feilen
                // Vis en feilsiden eller tilbake til hovedsiden
                return Content($"Feil ved lagring av data. Feilmelding: {ex.Message}");
        }
    }

        // Hvis skjemaet ikke er gyldig, vis det samme skjemaet igjen med feilmeldinger
        return View();
    }

}
