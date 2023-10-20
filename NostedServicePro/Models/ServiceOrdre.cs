using System;
using System.ComponentModel.DataAnnotations;

public class ServiceOrdre
{
    [Key]
    public int OrdreID { get; set; }

    public string Kundenavn { get; set; }
    public string Kundeepost { get; set; }
    public string Kundetlf { get; set; }
    public string Produkttypevinsj { get; set; }
    public int ÅrsmodellVinsj { get; set; }
    public string Serienummervinsj { get; set; }

    [Display(Name = "Registreringsdato")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime Registreringsdato { get; set; }

    public string AvtaltKommentar { get; set; }
    public string InternKommentar { get; set; }
    public string Problembeskrivelse { get; set; }
    public string ServiceType { get; set; }

    [Display(Name = "Avtalt leveringsdato")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime AvtaltleveringsDato { get; set; }

    [Display(Name = "Avtalt ferdigstillingsdato")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Avtaltferdigstillingsdato { get; set; }

    [Display(Name = "Produktmottatt dato")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime ProduktmottattDato { get; set; }
}
