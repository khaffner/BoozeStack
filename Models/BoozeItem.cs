using System.ComponentModel.DataAnnotations;

public class BoozeItem
{
    [Key]
    public long ProductNumber { get; set; }
    public string Source { get; set; }
    public string Name { get; set; }
    public string NameWithoutYear { get; set; }
    public int Year { get; set; }
    public float Price { get; set; }
    public float Volume { get; set; }
    public float PricePerLiter { get; set; }
    public string Category { get; set; }
    public string Container { get; set; }
    public float AlcoholPercentage { get; set; }
    public float PricePerAlcohol { get; set; }
}