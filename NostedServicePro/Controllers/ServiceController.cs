using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NostedServicePro.Data;

[Authorize]
public class ServiceController : Controller
{
    private readonly ServiceProDbContex _dbContext;

    // Konstruktør som injiserer databasekontekst
    public ServiceController(ServiceProDbContex dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult StartSjekkliste(int ordreID)
    {
        TempData["OrdreID"] = ordreID;
        return RedirectToAction("RegistrerSjekkliste");
    }

    public IActionResult ServiceOversikt()
    {
        var serviceordreListe = _dbContext.service.ToList();

        return View(serviceordreListe);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult RegistrerMottatt(int id)
    {
        var serviceOrdre = _dbContext.service.FirstOrDefault(s => s.OrdreID == id);

        if (serviceOrdre == null) return NotFound();

        // Oppdater ProduktmottattDato til dagens dato
        serviceOrdre.ProduktmottattDato = DateTime.Now;

        try
        {
            _dbContext.SaveChanges();

            TempData["Message"] = $"Mottak registrert for serviceordre #{id}!";
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Feil ved registrering av mottak: {ex.Message}";
            Console.WriteLine($"Exception: {ex}");
        }

        // Endre retur til ServiceOversikt
        return RedirectToAction(nameof(ServiceOversikt));
    }


    // Viser arkiv med filtrering og sortering
    public IActionResult Arkiv(string search, string sortOrder)
    {
        ViewData["SearchTerm"] = search; // Lagre søkeordet i ViewData
        ViewData["IdSortParm"] = string.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
        ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
        ViewData["EmailSortParm"] = sortOrder == "email" ? "email_desc" : "email";
        ViewData["DateSortParm"] = sortOrder == "date" ? "date_desc" : "date";

        var arkivData = _dbContext.service.AsQueryable();

        // Filtrering basert på søk
        if (!string.IsNullOrEmpty(search))
            arkivData = arkivData.Where(item =>
                item.Kundenavn.Contains(search) ||
                item.OrdreID.ToString().Contains(search) ||
                item.Kundeepost.Contains(search) ||
                item.Kundetlf.Contains(search)
            );

        // Sortering
        switch (sortOrder)
        {
            case "id_desc":
                arkivData = arkivData.OrderByDescending(item => item.OrdreID);
                break;
            case "name":
                arkivData = arkivData.OrderBy(item => item.Kundenavn);
                break;
            case "name_desc":
                arkivData = arkivData.OrderByDescending(item => item.Kundenavn);
                break;
            case "email":
                arkivData = arkivData.OrderBy(item => item.Kundeepost);
                break;
            case "email_desc":
                arkivData = arkivData.OrderByDescending(item => item.Kundeepost);
                break;
            case "date":
                arkivData = arkivData.OrderBy(item => item.Registreringsdato);
                break;
            case "date_desc":
                arkivData = arkivData.OrderByDescending(item => item.Registreringsdato);
                break;
            default:
                arkivData = arkivData.OrderBy(item => item.OrdreID);
                break;
        }

        var searchResult = arkivData.ToList();
        return View(searchResult);
    }

    // Hjelpemetode for å få sortering basert på attributt
    private Expression<Func<ServiceOrdre, object>> GetSortExpression(string currentSort)
    {
        switch (currentSort)
        {
            case "id":
                return item => item.OrdreID;
            case "name":
                return item => item.Kundenavn;
            case "email":
                return item => item.Kundeepost;
            case "date":
                return item => item.Registreringsdato;
            default:
                return item => item.OrdreID;
        }
    }


    // Viser skjemaet for å registrere en ny serviceordre
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult Registrer()
    {
        return View();
    }


    // Viser skjemaet for å registrere sjekkliste for en eksisterende serviceordre
    [HttpGet]
    public IActionResult RegistrerSjekkliste(int ordreId)
    {
        var sjekkliste = _dbContext.service.FirstOrDefault(s => s.OrdreID == ordreId);

        if (sjekkliste == null)
        {
            // Opprett ny ServiceOrdre hvis den ikke finnes
            sjekkliste = new ServiceOrdre { OrdreID = ordreId };
            _dbContext.service.Add(sjekkliste);
            _dbContext.SaveChanges();
        }

        return View(sjekkliste);
    }


    // Behandler postforespørsel for å registrere sjekkliste
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult RegistrerSjekkliste(ServiceOrdre model, string action)
    {
        var completeChecklist = action == "Fullfør sjekkliste";

        try
        {
            Console.WriteLine($"OrdreID received: {model.OrdreID}");

            if (ModelState.IsValid)
            {
                // Hent eksisterende serviceordre fra databasen
                var existingOrdre = _dbContext.service
                    .FirstOrDefault(ordre => ordre.OrdreID == model.OrdreID);

                if (existingOrdre != null)
                {
                    // Lagre ProduktmottattDato før du oppdaterer modellen
                    var produktmottattDato = existingOrdre.ProduktmottattDato;

                    // Oppdater sjekkpunktene og andre felter, ekskluder ProduktmottattDato
                    model.ProduktmottattDato = produktmottattDato;
                    _dbContext.Entry(existingOrdre).CurrentValues.SetValues(model);

                    // Marker sjekklisten som fullført hvis "Fullfør Sjekkliste" ble trykket
                    if (completeChecklist)
                    {
                        existingOrdre.ErSjekklisteFullført = true;
                        TempData["Message"] = $"Sjekkliste fullført for serviceordre #{model.OrdreID}!";
                    }
                    else
                    {
                        TempData["Message"] = $"Sjekkliste lagret for serviceordre #{model.OrdreID}!";
                    }

                    existingOrdre.Registreringsdato = DateTime.Now;

                    _dbContext.SaveChanges();

                    return RedirectToAction("Arkiv");
                }
            }
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Feil ved lagring av sjekkliste: {ex.Message}";
            Console.WriteLine($"Feil ved lagring av sjekkliste: {ex.Message}");
        }

        return View(model);
    }


    // Viser redigeringsskjema for en serviceordre
    public IActionResult Edit(int id)
    {
        var serviceOrdre = _dbContext.service.Find(id); //Henter frem fra DB
        if (serviceOrdre == null) return NotFound();
        return View(serviceOrdre); //Viser edit siden
    }

    // Viser detaljer for en serviceordre
    public IActionResult Details(int id)
    {
        var serviceOrdre = _dbContext.service.FirstOrDefault(s => s.OrdreID == id);

        if (serviceOrdre == null) return NotFound();

        return View(serviceOrdre);
    }

    // Viser slettingsskjema for en serviceordre
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        var serviceOrdre = _dbContext.service.Find(id);
        if (serviceOrdre == null) return NotFound();
        return View(serviceOrdre);
    }

    public IActionResult Print(int id)
    {
        var serviceOrdre = _dbContext.service.FirstOrDefault(s => s.OrdreID == id);

        if (serviceOrdre == null) return NotFound();

        return View(serviceOrdre);
    }

    // Behandler postforespørsel for å registrere en ny serviceordre
    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Registrer(ServiceOrdre serviceOrdre)
    {
        if (ModelState.IsValid)
        {
            serviceOrdre.Registreringsdato =
                DateTime.Now; //Dato med klokkeslett sendes inn basert på enheten de blir sendt inn fra
            _dbContext.Add(serviceOrdre);
            _dbContext.SaveChanges(); //Lagrer endringene

            TempData["Message"] = $"Serviceordre #{serviceOrdre.OrdreID} Registrert vellykket!";
            return RedirectToAction("Arkiv");
        }

        return View(serviceOrdre);
    }


    // Behandler postforespørsel for å redigere en serviceordre
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(ServiceOrdre model)
    {
        if (ModelState.IsValid)
            try
            {
                _dbContext.Entry(model).State = EntityState.Modified;
                _dbContext.SaveChanges();

                TempData["Message"] = $"Serviceordre #{model.OrdreID} endret vellykket!";
                return RedirectToAction("Arkiv");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.service.Any(e => e.OrdreID == model.OrdreID))
                    return NotFound();
                throw;
            }


        return View(model);
    }


    // Behandler postforespørsel for å slette en serviceordre
    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, bool confirm)
    {
        var serviceOrdre = _dbContext.service.Find(id);
        if (serviceOrdre == null) return NotFound();
        try
        {
            _dbContext.service.Remove(serviceOrdre);
            _dbContext.SaveChanges();
            TempData["Message"] = "Skjemaet ble slettet vellykket!";
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Feil ved sletting av skjema: {ex.Message}";

            // Lagt til logging
            Console.WriteLine($"Exception: {ex}");
        }

        // Endre retur til arkiv
        return RedirectToAction(nameof(Arkiv));
    }
}