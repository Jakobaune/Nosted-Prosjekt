using System.ComponentModel.DataAnnotations;

// Egendefinert valideringsattributt for å sikre at en dato er i fremtiden og uten tidspunkt
public class FutureDateAttribute : ValidationAttribute
{
    // Metode for å validere om datoen er i fremtiden og uten tidspunkt
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // Sjekk om verdien er av typen DateTime
        if (value is DateTime date)
        {
            // Sjekk om datoen er tidligere enn dagens dato eller har et tidspunkt forskjellig fra midnatt
            if (date.Date < DateTime.Now.Date)
            {
                // Returner en ValidationResult med feilmelding hvis betingelsen ikke er oppfylt
                return new ValidationResult("Datoen kan ikke være tidligere enn dagens dato.");
            }
        }

        // Returner ValidationResult.Success hvis betingelsen er oppfylt
        return ValidationResult.Success;
    }
}
