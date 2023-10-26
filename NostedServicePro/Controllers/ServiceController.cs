using Loginnosted.Data;
using Loginnosted.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;

public class ServiceController : Controller
{
    private readonly ServiceProDbContex _dbContext;

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



    public IActionResult Arkiv(string search, string sortOrder)
    {
        ViewData["IdSortParm"] = string.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
        ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
        ViewData["EmailSortParm"] = sortOrder == "email" ? "email_desc" : "email";
        ViewData["DateSortParm"] = sortOrder == "date" ? "date_desc" : "date";

        var arkivData = _dbContext.service.AsQueryable();

        // Filtrering basert på søk
        if (!string.IsNullOrEmpty(search))
        {
            arkivData = arkivData.Where(item =>
                item.Kundenavn.Contains(search) ||
                item.OrdreID.ToString().Contains(search) ||
                item.Kundeepost.Contains(search) ||
                item.Kundetlf.Contains(search)
            );
        }

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


    [HttpGet]
    public IActionResult Registrer()
    {
        return View(); // Vis skjemaet for å bestille service
    }
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult FerdigstillSjekkliste(ServiceOrdre model)
    {
     
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
                    // Oppdater sjekkpunktene og andre felter
                    _dbContext.Entry(existingOrdre).CurrentValues.SetValues(model);

                    // Marker sjekklisten som fullført
                    existingOrdre.ErSjekklisteFullført = true;

                    _dbContext.SaveChanges();

                    return RedirectToAction("Arkiv");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Feil ved lagring av sjekkliste: {ex.Message}");
        }

        return View(model);
    }








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

    public IActionResult Edit(int id)
    {
        var serviceOrdre = _dbContext.service.Find(id);
        if (serviceOrdre == null)
        {
            return NotFound();
        }
        return View(serviceOrdre);
    }

    public IActionResult Details(int id)
    {
        var serviceOrdre = _dbContext.service.FirstOrDefault(s => s.OrdreID == id);

        if (serviceOrdre == null)
        {
            return NotFound();
        }

        return View(serviceOrdre);
    }


    public IActionResult Delete(int id)
    {
        var serviceOrdre = _dbContext.service.Find(id);
        if (serviceOrdre == null)
        {
            return NotFound();
        }
        return View(serviceOrdre);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Registrer(ServiceOrdre serviceOrdre)
    {
        if (ModelState.IsValid)
        {
            serviceOrdre.Registreringsdato = DateTime.Now;
            _dbContext.Add(serviceOrdre);
            _dbContext.SaveChanges();

            return RedirectToAction("Arkiv");
        }

        return View(serviceOrdre);
    }




    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(ServiceOrdre model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _dbContext.Entry(model).State = EntityState.Modified;
                _dbContext.SaveChanges();

                TempData["Message"] = $"Serviceordre #{model.OrdreID} endret vellykket!";
                return RedirectToAction(nameof(Arkiv));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.service.Any(e => e.OrdreID == model.OrdreID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, bool confirm)
    {
        var serviceOrdre = _dbContext.service.Find(id);
        if (serviceOrdre == null)
        {
            return NotFound();
        }
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
