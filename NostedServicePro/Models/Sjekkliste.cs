using System.Collections;

namespace Loginnosted.Models
{
    public class Sjekkliste : IEnumerable<Sjekkliste>
    {
        public int Id { get; set; }
        public string KundeNavn { get; set; }
        public List<SjekklisteElement> SjekklisteElement { get; set; }

        public IEnumerator<Sjekkliste> GetEnumerator()
        {
            return this.SjekklisteElement.Cast<Sjekkliste>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}