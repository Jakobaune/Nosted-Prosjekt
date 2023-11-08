using System;
using System.ComponentModel.DataAnnotations;

public class ServiceOrdre
{
    [Key]
    public int OrdreID { get; set; }

    [Required]
    public string Kundenavn { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "E-postadressen må inneholde en '@' og ha riktig format.")]
    public string Kundeepost { get; set; }
    [Required]
    
    [RegularExpression(@"^\d{8}$", ErrorMessage = "Telefonnummeret må bestå av 8 siffer.")]
    public string Kundetlf { get; set; }
    [Required]
    public string Produkttypevinsj { get; set; }
    [Required]
    public int ÅrsmodellVinsj { get; set; }
    [Required]
   
    [RegularExpression("^[0-9]*$", ErrorMessage = "Serienummeret må bestå av tall.")]
    public string Serienummervinsj { get; set; }

    [Required]
    [Display(Name = "Registreringsdato")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime Registreringsdato { get; set; }
    [Required]
    public string AvtaltKommentar { get; set; }
    [Required]
    public string InternKommentar { get; set; }
    [Required]
    public string Problembeskrivelse { get; set; }
    [Required]
    public string ServiceType { get; set; }
    [Required]
    [Display(Name = "Avtalt leveringsdato")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [FutureDate(ErrorMessage = "Datoen kan ikke være tidligere enn dagens dato.")]
    public DateTime AvtaltleveringsDato { get; set; }

    [Required]
    [Display(Name = "Avtalt ferdigstillingsdato")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [FutureDate(ErrorMessage = "Datoen kan ikke være tidligere enn dagens dato.")]
    public DateTime Avtaltferdigstillingsdato { get; set; }

    [Display(Name = "Produktmottatt dato")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [FutureDate(ErrorMessage = "Datoen kan ikke være tidligere enn dagens dato.")]
    public DateTime? ProduktmottattDato { get; set; }

    //Sjekkliste under

    public String? ClutchLameller { get; set; }
    public String? Bremser { get; set; }
    public String? LagerTrommel { get; set; }
    public String? PTOOpplagring { get; set; }
    public String? Kjedestrammer { get; set; }
    public String? Wire { get; set; }
    public String? PlnlonLager { get; set; }
    public String? KilleKjedehjul { get; set; }
    public String? HydraulikkSylinderLekkasje { get; set; }
    public String? SlangerSkaderLekkasje { get; set; }
    public String? TestHydraulikkblokk { get; set; }
    public String? SkiftOljeTank { get; set; }
    public String? SkiftOljeGirboks { get; set; }
    public String? RingsyllingerSkiftTelnlnger { get; set; }
    public String? BremsesylingerSkiftTelninger { get; set; }
    public String? LedningsnettVinsj { get; set; }
    public String? SjekkTestRadio { get; set; }
    public String? SjekkTestKnappekasse { get; set; }
    public String? XXBar { get; set; }
    public String? TestVinsjAlleFunksjoner { get; set; }
    public String? TrekkraftKn { get; set; }
    public String? BremsekraftKn { get; set; }

    public Double? Arbeidstimer { get; set; }

    public String? Kommentar { get; set; }
    public bool ErSjekklisteFullført { get; set; }
}
