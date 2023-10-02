using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Nøsted_ServicePro.Models;
using Newtonsoft.Json;


namespace Nøsted_ServicePro.Controllers.ServiceRegistrering;

public class ServiceRegistreringController : Controller
{
    private readonly ILogger<ServiceRegistreringController> _logger;

    public ServiceRegistreringController(ILogger<ServiceRegistreringController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult LagreServiceOrdre(ServiceOrderModel model)
    {
        var kundenavn = model.KundeNavn;
        var vinsjid = model.VinsjID;
        var kommentar = model.KundeKommentar;

        // Create an instance of ServiceOrderModel and set the values
        var viewModel = new ServiceOrderModel
        {
            KundeNavn = kundenavn,
            VinsjID = vinsjid,
            KundeKommentar = kommentar
        };

        // Serialize the model to JSON and store it in TempData
        TempData["ServiceOrderModel"] = Newtonsoft.Json.JsonConvert.SerializeObject(viewModel);

        // Redirect to Serviceskjema action
        return RedirectToAction("Index");
    }

    public IActionResult Serviceskjema()
    {
        // Retrieve the model data from TempData
        var modelJson = TempData["ServiceOrderModel"] as string;

        // Check for null to handle edge cases
        if (modelJson == null)
        {
            // Handle the case where TempData is empty
            return RedirectToAction("Index");
        }

        // Deserialize the JSON string to ServiceOrderModel
        var model = Newtonsoft.Json.JsonConvert.DeserializeObject<ServiceOrderModel>(modelJson);

        return View(model);
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


