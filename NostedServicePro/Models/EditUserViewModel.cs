using System.ComponentModel.DataAnnotations;

// Modellklasse for redigering av brukerinformasjon
public class EditUserViewModel
{
    // Brukerens ID
    public string UserId { get; set; }

    // Egenskap for brukernavn med påkrevd validering og tilpasset feilmelding
    [Required(ErrorMessage = "Brukernavn er påkrevd.")]
    [Display(Name = "Brukernavn")]
    public string UserName { get; set; }

    // Egenskap for e-postadresse med påkrevd validering, e-postvalidering og tilpasset feilmelding
    [Required(ErrorMessage = "E-postadresse er påkrevd.")]
    [EmailAddress(ErrorMessage = "Ugyldig e-postadresse.")]
    [Display(Name = "E-postadresse")]
    public string Email { get; set; }

    // Liste over nåværende roller tilknyttet brukeren
    [Display(Name = "Nåværende roller")]
    public List<string> CurrentRoles { get; set; }

    // Liste over valgte roller for brukeren
    [Display(Name = "Velg roller")]
    public List<string> SelectedRoles { get; set; }
}
