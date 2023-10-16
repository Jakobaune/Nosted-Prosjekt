namespace Loginnosted.Models
{
    public class Sjekkliste
    {
        public int Id { get; set; }
        public string KundeNavn { get; set; }
        public List<SjekklisteElement> SjekklisteElement { get; set; }
    }
}
