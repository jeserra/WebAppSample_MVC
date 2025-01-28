namespace WebAppSample.Models;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    public long Population { get; set; }
    public double SizeInSquareMeters { get; set; }
    public int? IndependenceYear { get; set; }
    public string Language { get; set; }
    public string Currency { get; set; }
    public string CapitalCity { get; set; }
}
