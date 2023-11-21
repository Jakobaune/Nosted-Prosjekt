using System.ComponentModel.DataAnnotations;

public class ServiceOrdre
{
    [Key] public int OrdreID { get; set; }

    [Required(ErrorMessage = "Kundenavn er obligatorisk.")]
    public string Kundenavn { get; set; }

    [Required(ErrorMessage = "E-postadressen er obligatorisk og må ha riktig format.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public string Kundeepost { get; set; }

    
    [Required(ErrorMessage = "Telefonnummer er obligatorisk.")]
    public string Kundetlf { get; set; }

    [Required(ErrorMessage = "Produkttypevinsj er obligatorisk.")]
    public string Produkttypevinsj { get; set; }

    [Required(ErrorMessage = "Årsmodellvinsj er obligatorisk.")]
    public int ÅrsmodellVinsj { get; set; }

    [Required(ErrorMessage = "Serienummervinsj er obligatorisk.")]
    public string Serienummervinsj { get; set; }

    [Required(ErrorMessage = "Registreringsdato er obligatorisk.")]
    [Display(Name = "Registreringsdato")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
   
    
    public DateTime Registreringsdato { get; set; }

    [Required(ErrorMessage = "Avtalt kommentar er obligatorisk.")]
    public string AvtaltKommentar { get; set; }

    
    [Required(ErrorMessage = "Intern kommentar er obligatorisk.")]
    public string InternKommentar { get; set; }

    
    [Required(ErrorMessage = "Problembeskrivelse er obligatorisk.")]
    public string Problembeskrivelse { get; set; }

    [Required(ErrorMessage = "ServiceType er obligatorisk.")]
    public string ServiceType { get; set; }

    [Required(ErrorMessage = "Avtalt leveringsdato er obligatorisk.")]
    [Display(Name = "Avtalt leveringsdato")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [FutureDate(ErrorMessage = "Avtalt leveringsdato kan ikke være tidligere enn dagens dato.")]
    public DateTime AvtaltleveringsDato { get; set; }

    [Required(ErrorMessage = "Avtalt ferdigstillingsdato er obligatorisk.")]
    [Display(Name = "Avtalt ferdigstillingsdato")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    
    
    [FutureDate(ErrorMessage = "Avtalt ferdigstillingsdato kan ikke være tidligere enn dagens dato.")]
    public DateTime Avtaltferdigstillingsdato { get; set; }

    [Display(Name = "Produktmottatt dato")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    
    [FutureDate(ErrorMessage = "Produktmottatt dato kan ikke være tidligere enn dagens dato.")]
    public DateTime? ProduktmottattDato { get; set; }

    [Required(ErrorMessage = "Registrert av er obligatorisk")]
    public string RegistreringFullførtAv { get; set; }

    //Sjekkliste under

    public string? ClutchLameller { get; set; }
    public string? Bremser { get; set; }
    public string? LagerTrommel { get; set; }
    public string? PTOOpplagring { get; set; }
    public string? Kjedestrammer { get; set; }
    public string? Wire { get; set; }
    public string? PlnlonLager { get; set; }
    public string? KilleKjedehjul { get; set; }
    public string? HydraulikkSylinderLekkasje { get; set; }
    public string? SlangerSkaderLekkasje { get; set; }
    public string? TestHydraulikkblokk { get; set; }
    public string? SkiftOljeTank { get; set; }
    public string? SkiftOljeGirboks { get; set; }
    public string? RingsyllingerSkiftTelnlnger { get; set; }
    public string? BremsesylingerSkiftTelninger { get; set; }
    public string? LedningsnettVinsj { get; set; }
    public string? SjekkTestRadio { get; set; }
    public string? SjekkTestKnappekasse { get; set; }
    public string? XXBar { get; set; }
    public string? TestVinsjAlleFunksjoner { get; set; }
    public string? TrekkraftKn { get; set; }
    public string? BremsekraftKn { get; set; }

    public double? Arbeidstimer { get; set; }

    public string? Kommentar { get; set; }
    public string? SjekkListeFullførtAv { get; set; }
    public bool ErSjekklisteFullført { get; set; }
}