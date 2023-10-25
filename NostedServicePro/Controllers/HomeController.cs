using Loginnosted.Data;
using Loginnosted.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class HomeController : Controller
{
    private readonly ServiceProDbContex _dbContext;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ServiceProDbContex dbContext, ILogger<HomeController> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    public IActionResult Index()
    {
        try
        {
            var uferdigeServiceOrdre = _dbContext.service.Where(ordre => !ordre.ErSjekklisteFullført).ToList();
            return View(uferdigeServiceOrdre);
        }
        catch (Exception ex)
        {
            // Logg eller håndter feilen på en passende måte
            return View("Error"); // Vis feilsiden
        }
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
