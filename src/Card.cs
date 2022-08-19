namespace Hypercube;

public class Card
{
    public string ScryfallReference { get; init; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ManaCost { get; set; } = string.Empty;
    public string Frame { get; set; } = string.Empty;
    public List<string> Supertypes { get; set; } = new();
    public List<string> Types { get; set; } = new();
    public List<string> Subtypes { get; set; } = new();
    public string CardText { get; set; } = string.Empty;
    public string Power { get; set; } = string.Empty;
    public string Toughness { get; set; } = string.Empty;
    public bool HasPowerAndToughness => !string.IsNullOrEmpty(Power) || !string.IsNullOrEmpty(Toughness);
    public string Rarity { get; set; } = string.Empty;
    public int FontSize { get; set; } = 11;
}
