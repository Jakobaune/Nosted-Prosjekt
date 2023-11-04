using NostedServicePro.Models;

// Modellklasse som representerer en bruker i systemet
public class Bruker
{
    // Unik identifikator for brukeren
    public int BrukerId { get; set; }

    // Brukerens navn
    public string BrukerNavn { get; set; }

    // Brukerens e-postadresse
    public string Epostadresse { get; set; }

    // Brukerens rolle i systemet
    public string Rolle { get; set; }

    // Privat felt for lagring av salt-verdi for passordhashing
    private string _salt;

    // Offentlig egenskap for passord med automatisk hashing ved oppdatering
    public string Passord
    {
        // Hent passord med salt og hash
        get { return BCrypt.Net.BCrypt.HashPassword(_salt + _passord); }

        // Sett passord og generer ny salt-verdi
        set
        {
            _salt = BCrypt.Net.BCrypt.GenerateSalt();
            _passord = value;
        }
    }

    // Privat felt for lagring av passord
    private string _passord;
}
