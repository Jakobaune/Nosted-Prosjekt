using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nostedansatt;
using Nostedansatt.Models; // Endret namespace

public class RegistreringsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<RegistreringsController> _logger;

    public RegistreringsController(ApplicationDbContext context, ILogger<RegistreringsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Skjema()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Skjema(Nostedansatt.Models.Ansatt ansatt)
    {

            if (!ModelState.IsValid)
            {
                // Logg valideringsfeil
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogError($"ModelState error: {error.ErrorMessage}");
                }

                return View();
            }
            try
        {
            if (ModelState.IsValid)
            {
                // Sjekk og sett verdier før lagring i databasen
                if (string.IsNullOrWhiteSpace(ansatt.BrukerNavn))
                    ModelState.AddModelError("BrukerNavn", "BrukerNavn er påkrevd.");

                if (string.IsNullOrWhiteSpace(ansatt.EpostAdresse))
                    ModelState.AddModelError("EpostAdresse", "EpostAdresse er påkrevd.");

                if (string.IsNullOrWhiteSpace(ansatt.Rolle))
                    ModelState.AddModelError("Rolle", "Rolle er påkrevd.");

                if (string.IsNullOrWhiteSpace(ansatt.Passord))
                    ModelState.AddModelError("Passord", "Passord er påkrevd.");

                if (ModelState.IsValid)
                {
                    _context.Brukere.Add(ansatt);
                    _context.SaveChanges();
                    _logger.LogInformation("Bruker registrert vellykket!");
                    TempData["Melding"] = "Bruker registrert vellykket!";
                    return RedirectToAction("Skjema");
                }
            }
        }
        catch (Exception ex)
        {
            // Logg feil
            _logger.LogError($"Feil ved lagring av bruker: {ex.Message}");
            TempData["Feilmelding"] = "Feil ved lagring av bruker.";
        }

        return View();
    }
}
