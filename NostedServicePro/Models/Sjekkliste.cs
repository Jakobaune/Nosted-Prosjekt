using System.ComponentModel.DataAnnotations;

public class Sjekkliste
{
    [Key]
    public int Id { get; set; }

    public String ClutchLameller { get; set; }
    public String Bremser { get; set; }
    public String LagerTrommel { get; set; }
    public String PTOOpplagring { get; set; }
    public String Kjedestrammer { get; set; }
    public String Wire { get; set; }
    public String PlnlonLager { get; set; }
    public String KilleKjedehjul { get; set; }
    public String HydraulikkSylinderLekkasje { get; set; }
    public String SlangerSkaderLekkasje { get; set; }
    public String TestHydraulikkblokk { get; set; }
    public String SkiftOljeTank { get; set; }
    public String SkiftOljeGirboks { get; set; }
    public String RingsyllingerSkiftTelnlnger { get; set; }
    public String BremsesylingerSkiftTelninger { get; set; }
    public String LedningsnettVinsj { get; set; }
    public String SjekkTestRadio { get; set; }
    public String SjekkTestKnappekasse { get; set; }
    public String XXBar { get; set; }
    public String TestVinsjAlleFunksjoner { get; set; }
    public String TrekkraftKn { get; set; }
    public String BremsekraftKn { get; set; }
 
    
}
