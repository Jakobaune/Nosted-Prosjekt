using System.ComponentModel.DataAnnotations.Schema;

namespace NostedServicePro.Entities
{
    [Table("Dyr")]
    public class Dyr
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}