using Loginnosted.Data;
using Loginnosted.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;

public class SjekklisteController : Controller
{
    private readonly LoginnostedDbContext _dbContext;

    public SjekklisteController(LoginnostedDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult VisSjekkliste()
    {
        var sjekkpunkter = _dbContext.SjekklisteElement.Select(e => e.Sjekkpunkt).Distinct().ToList();
        return View(sjekkpunkter);
    }
    private List<SjekklisteElementStatus> GetSjekkpunkter()
    {
        return _dbContext.SjekklisteElement.Select(e => new SjekklisteElementStatus
        {
            Id = e.Id,
            Sjekkpunkt = e.Sjekkpunkt,
            Status = e.Status // Endret fra null til e.Status
        }).ToList();
    }

    public IActionResult LeggTilSjekklisteElement()
    {
        var sjekkpunkter = GetSjekkpunkter();
        var viewModel = new SjekklisteStatusViewModel
        {
            Sjekkpunkter = sjekkpunkter
        };
        return View(viewModel);
    }


    public IActionResult VisSjekklisteMedStatus()
    {
        var sjekklisteMedStatus = _dbContext.SjekklisteElement
            .Select(e => new SjekklisteElementMedStatus
            {
                Sjekkpunkt = e.Sjekkpunkt,
                Status = e.Status // Antar at du har en egenskap kalt Status i SjekklisteElement-modellen
            })
            .Distinct()
            .ToList();

        return View(sjekklisteMedStatus);
    }

    [HttpPost]
    public IActionResult LeggTilSjekklisteElement(SjekklisteStatusViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                foreach (var sjekkpunkt in viewModel.Sjekkpunkter)
                {
                    var sjekklisteElement = new SjekklisteElement
                    {
                        Id = sjekkpunkt.Id,
                        Status = sjekkpunkt.Status
                    };

                    _dbContext.Entry(sjekklisteElement).Property(x => x.Status).IsModified = true;
                }

                _dbContext.SaveChanges();
                return Content("Sjekklisteelement lagret vellykket!");
            }
            catch (Exception ex)
            {
                return Content($"Feil ved lagring av sjekklisteelement. Feilmelding: {ex.Message}");
            }
        }
        return View(viewModel);
    }








    public IActionResult RedigerSjekklisteElement(int id)
    {
        var sjekklisteElement = _dbContext.SjekklisteElement.Find(id);
        return View(sjekklisteElement);
    }

    [HttpPost]
    public IActionResult RedigerSjekklisteElement(SjekklisteElement sjekklisteElement)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _dbContext.Entry(sjekklisteElement).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(ListeAvSjekklisteElementer));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.SjekklisteElement.Any(e => e.Id == sjekklisteElement.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return View(sjekklisteElement);
    }

    public IActionResult SlettSjekklisteElement(int id)
    {
        var sjekklisteElement = _dbContext.SjekklisteElement.Find(id);
        return View(sjekklisteElement);
    }

    public IActionResult ListeAvSjekklisteElementer()
    {
        var sjekklisteElementer = _dbContext.SjekklisteElement.ToList();
        return View(sjekklisteElementer);
    }
}
