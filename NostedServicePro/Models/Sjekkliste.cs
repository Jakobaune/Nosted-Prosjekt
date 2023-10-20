using System.ComponentModel.DataAnnotations;

public class Sjekkliste
{
    [Key]
    public int Id { get; set; }

    public Status ClutchLameller { get; set; }
    public Status Bremser { get; set; }
    public Status LagerTrommel { get; set; }
    public Status PTOOpplagring { get; set; }
    public Status Kjedestrammer { get; set; }
    public Status Wire { get; set; }
    public Status PlnlonLager { get; set; }
    public Status KilleKjedehjul { get; set; }
    public Status HydraulikkSylinderLekkasje { get; set; }
    public Status SlangerSkaderLekkasje { get; set; }
    public Status TestHydraulikkblokk { get; set; }
    public Status SkiftOljeTank { get; set; }
    public Status SkiftOljeGirboks { get; set; }
    public Status RingsyllingerSkiftTelnlnger { get; set; }
    public Status BremsesylingerSkiftTelninger { get; set; }
    public Status LedningsnettVinsj { get; set; }
    public Status SjekkTestRadio { get; set; }
    public Status SjekkTestKnappekasse { get; set; }
    public Status XXBar { get; set; }
    public Status TestVinsjAlleFunksjoner { get; set; }
    public Status TrekkraftKn { get; set; }
    public Status BremsekraftKn { get; set; }

    public enum Status
    {
        [Display(Name = "OK")]
        OK,
        [Display(Name = "Bør skiftes")]
        BørSkiftes,
        [Display(Name = "Defekt")]
        Defekt
    }
}
