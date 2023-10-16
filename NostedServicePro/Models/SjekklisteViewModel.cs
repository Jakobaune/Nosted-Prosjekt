namespace Loginnosted.Models
{
    public class SjekklisteViewModel
    {
        public List<SjekklisteElement> Sjekkpunkter { get; set; }
        public Dictionary<string, string> SelectedSjekkpunkter { get; set; }
    }
}