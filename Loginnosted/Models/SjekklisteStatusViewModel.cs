    namespace Loginnosted.Models
    {
        public class SjekklisteStatusViewModel
        {
            public List<SjekklisteElementStatus> Sjekkpunkter { get; set; }
        }

        public class SjekklisteElementStatus
        {
            public int Id { get; set; }

        public string Sjekkpunkt { get; set; }
            public string Status { get; set; }
        }
    }
