using System;
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
    public int ÅrsmodellVinsj { get; set; }
    public string Serienummervinsj { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Registreringsdato { get; set; }

    public string AvtaltKommentar { get; set; }
    public string InternKommentar { get; set; }
    public string Problembeskrivelse { get; set; }
    public string ServiceType { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly AvtaltleveringsDato { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly Avtaltferdigstillingsdato { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly ProduktmottattDato { get; set; }

}
