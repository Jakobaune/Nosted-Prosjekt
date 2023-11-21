using System.ComponentModel.DataAnnotations;

public class EditUserViewModel
{
    public string UserId { get; set; }

    [Required(ErrorMessage = "Brukernavn er påkrevd.")]
    [Display(Name = "Brukernavn")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "E-postadresse er påkrevd.")]
    [EmailAddress(ErrorMessage = "Ugyldig e-postadresse.")]
    [Display(Name = "E-postadresse")]
    public string Email { get; set; }

    [Display(Name = "Nåværende roller")]
    public List<string> CurrentRoles { get; set; }

    [Display(Name = "Velg roller")]
    public List<string> SelectedRoles { get; set; }
}
