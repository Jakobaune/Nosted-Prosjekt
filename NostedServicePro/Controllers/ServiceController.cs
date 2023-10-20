using Loginnosted.Data;
using Loginnosted.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public class ServiceController : Controller
{
    private readonly ServiceProDbContex _dbContext;

    public ServiceController(ServiceProDbContex dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Registrer()
    {
        return View(); // Vis skjemaet for å bestille service
    }

    public IActionResult Arkiv(string search)
    {
        var arkivData = _dbContext.service.AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            arkivData = arkivData.Where(item =>
                item.Kundenavn.Contains(search) ||
                item.OrdreID.ToString().Contains(search) ||
                item.Kundeepost.Contains(search) ||
                item.Kundetlf.Contains(search)
            );
        }

        var searchResult = arkivData.ToList();
        return View(searchResult);
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
        var serviceOrdre = _dbContext.service.Find(id);
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
    public IActionResult Registrer(ServiceOrdre serviceOrdre)
    {
        if (ModelState.IsValid)
        {
            try
            {
                // Sett registreringsdato til nåværende dato og klokkeslett
                serviceOrdre.Registreringsdato = DateTime.Now;

                _dbContext.service.Add(serviceOrdre);
                _dbContext.SaveChanges();

                TempData["Message"] = $"Serviceordre #{serviceOrdre.OrdreID} laget vellykket!";
                return RedirectToAction(nameof(Arkiv));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Feil ved lagring av data. Feilmelding: {ex.Message}";
            }
        }

        return View();
    }




    [HttpPost]
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
