using System.ComponentModel.DataAnnotations;

public class ServiceOrdre
{
    // Auto-genereres av databasen

    [Key]
    public int OrdreID { get; set; }

    public string Kundenavn { get; set; }
    public string Kundeepost { get; set; }
    public string Kundetlf { get; set; }
    public string Produkttypevinsj { get; set; }
    public string ÅrsmodellVinsj { get; set; }
    public string Serienummervinsj { get; set; }
    public DateTime Registreringsdato { get; set; }
    public string AvtaltKommentar { get; set; }
    public string InternKommentar { get; set; }
    public string Problembeskrivelse { get; set; }
    public string ServiceType { get; set; }
    public DateTime AvtaltleveringsDato { get; set; }
    public DateTime Avtaltferdigstillingsdato { get; set; }
    public DateTime ProduktmottattDato { get; set; }
}
