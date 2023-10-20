using Microsoft.AspNetCore.Mvc;
using Loginnosted.Models; // Sørg for å inkludere riktig namespace for din Sjekkliste-modell
using Microsoft.EntityFrameworkCore;
using Loginnosted.Data;

namespace DinProsjekt.Controllers
{
    public class SjekklisteController : Controller
    {
        private readonly ServiceProDbContex _context; // Bytt ut "YourDbContext" med din faktiske databasekontekstklasse

        public SjekklisteController(ServiceProDbContex context)
        {
            _context = context;
        }
        public IActionResult SjekklisteListe()
        {
            var sjekklister = _context.Sjekkliste.ToList();
            return View(sjekklister);
        }


        // Viser listen over sjekklister
        public IActionResult Sjekking()
        {
            var sjekklister = _context.Sjekkliste.ToList();
            return View(sjekklister);
        }



        // Viser detaljer for en spesifikk sjekkliste
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sjekkliste = _context.Sjekkliste.FirstOrDefault(m => m.Id == id);
            if (sjekkliste == null)
            {
                return NotFound();
            }

            return View(sjekkliste);
        }

        // Viser skjemaet for å opprette en ny sjekkliste
        public IActionResult Create()
        {
            return View();
        }

        // Lagrer en ny sjekkliste i databasen
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sjekkliste sjekkliste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sjekkliste);
                _context.SaveChanges();
                return RedirectToAction(nameof(Sjekking));
            }
            return View(sjekkliste);
        }

        // Viser skjemaet for å redigere en eksisterende sjekkliste
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sjekkliste = _context.Sjekkliste.FirstOrDefault(m => m.Id == id);
            if (sjekkliste == null)
            {
                return NotFound();
            }

            return View(sjekkliste);
        }

        // Lagrer endringene for en eksisterende sjekkliste i databasen
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Sjekkliste sjekkliste)
        {
            if (id != sjekkliste.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sjekkliste);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SjekklisteExists(sjekkliste.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Sjekking));
            }
            return View(sjekkliste);
        }

        // Viser skjemaet for å slette en eksisterende sjekkliste
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sjekkliste = _context.Sjekkliste.FirstOrDefault(m => m.Id == id);
            if (sjekkliste == null)
            {
                return NotFound();
            }

            return View(sjekkliste);
        }

        // Sletter en eksisterende sjekkliste fra databasen
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var sjekkliste = _context.Sjekkliste.Find(id);
            _context.Sjekkliste.Remove(sjekkliste);
            _context.SaveChanges();
            return RedirectToAction(nameof(Sjekking));
        }

        // Hjelpefunksjon for å sjekke om en sjekkliste eksisterer i databasen
        private bool SjekklisteExists(int id)
        {
            return _context.Sjekkliste.Any(e => e.Id == id);
        }
    }
}
