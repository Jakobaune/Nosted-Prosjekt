using Loginnosted.Data;
using Loginnosted.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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

    public IActionResult Arkiv()
    {
        var arkivData = _dbContext.service.ToList(); // Hent alle dataene fra databasen
        return View(arkivData);
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
    public IActionResult Index(ServiceOrdre serviceOrdre)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _dbContext.service.Add(serviceOrdre);
                _dbContext.SaveChanges();
                return Content("Data lagret vellykket!");
            }
            catch (Exception ex)
            {
                return Content($"Feil ved lagring av data. Feilmelding: {ex.Message}");
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

    // Endre retur til Index
    return RedirectToAction(nameof(Index));
}



}
