using System;
using System.ComponentModel.DataAnnotations;

public class ServiceOrdre
{
    [Key]
    public int OrdreID { get; set; }

    [Required(ErrorMessage = "Kundenavn er obligatorisk.")]
    public string Kundenavn { get; set; }

    [Required(ErrorMessage = "E-postadressen er obligatorisk og må ha riktig format.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public string Kundeepost { get; set; }

    
    public string Kundetlf { get; set; }

    [Required(ErrorMessage = "Produkttypevinsj er obligatorisk.")]
    public string Produkttypevinsj { get; set; }

    public int ÅrsmodellVinsj { get; set; }

    public string Serienummervinsj { get; set; }

    [Required]
    [Display(Name = "Registreringsdato")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime Registreringsdato { get; set; }

    public string AvtaltKommentar { get; set; }

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

    [Required(ErrorMessage = "Registrert av?")]
    public String RegistreringFullførtAv { get; set; }

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
    public String? SjekkListeFullførtAv { get; set; }
    public bool ErSjekklisteFullført { get; set; }
}

/*
    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? ClutchLameller { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? Bremser { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? LagerTrommel { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? PTOOpplagring { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? Kjedestrammer { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? Wire { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? PlnlonLager { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? KilleKjedehjul { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? HydraulikkSylinderLekkasje { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? SlangerSkaderLekkasje { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? TestHydraulikkblokk { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? SkiftOljeTank { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? SkiftOljeGirboks { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? RingsyllingerSkiftTelnlnger { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? BremsesylingerSkiftTelninger { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? LedningsnettVinsj { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? SjekkTestRadio { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? SjekkTestKnappekasse { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? XXBar { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? TestVinsjAlleFunksjoner { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? TrekkraftKn { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public String? BremsekraftKn { get; set; }

    [Required(ErrorMessage = "Må gjøres for å fullføre!")]
    public Double? Arbeidstimer { get; set; }

    public String? Kommentar { get; set; }
    public String? SjekkListeFullførtAv { get; set; }
    public bool ErSjekklisteFullført { get; set; }
*/