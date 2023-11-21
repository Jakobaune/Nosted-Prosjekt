namespace NostedServicePro.Models
{
    // Modellklasse som representerer brukerens informasjon sammen med roller
    public class BrukerMedRollerViewModel
    {
        // Brukerens ID
        public string UserId { get; set; }

        // Brukerens navn
        public string UserName { get; set; }

        // Brukerens e-postadresse
        public string Email { get; set; }

        // Liste over roller tilknyttet brukeren
        public IList<string> Roller { get; set; }

        // Liste over alle tilgjengelige roller
        public IList<string> AlleRoller { get; set; }
    }
}
