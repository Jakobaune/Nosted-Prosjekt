using Loginnosted.Models;

public class Bruker
{
    public int BrukerId { get; set; }
    public string BrukerNavn { get; set; }
    public string Epostadresse { get; set; }
    public string Rolle { get; set; }

    private string _salt;

    public string Passord
    {
        get { return BCrypt.Net.BCrypt.HashPassword(_salt + _passord); }
        set
        {
            _salt = BCrypt.Net.BCrypt.GenerateSalt();
            _passord = value;
        }
    }

    private string _passord;
}


