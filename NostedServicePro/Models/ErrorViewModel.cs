namespace NostedServicePro.Models
{
    // Modellklasse for feilvisning
    public class ErrorViewModel
    {
        // Forespørsels-ID knyttet til feilen
        public string? RequestId { get; set; }

        // Egenskap som returnerer true hvis RequestId ikke er null eller tom
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
