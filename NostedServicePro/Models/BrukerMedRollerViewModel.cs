namespace NostedServicePro.Models
{
    public class BrukerMedRollerViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IList<string> Roller { get; set; }
        public IList<string> AlleRoller { get; set; }
    }
}
