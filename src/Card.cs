using System.Text.Json.Serialization;

namespace Hypercube;

public class Card : IComparable<Card>
{
    private static ScryfallReferenceComparer comparer = new ScryfallReferenceComparer();

    [JsonPropertyOrder(1)]
    public string ScryfallReference { get; init; } = string.Empty;

    [JsonPropertyOrder(2)]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyOrder(3)]
    public string ManaCost { get; set; } = string.Empty;

    [JsonPropertyOrder(4)]
    public string Frame { get; set; } = string.Empty;

    [JsonPropertyOrder(5)]
    public List<string> Supertypes { get; set; } = new();

    [JsonPropertyOrder(6)]
    public List<string> Types { get; set; } = new();

    [JsonPropertyOrder(7)]
    public List<string> Subtypes { get; set; } = new();

    [JsonPropertyOrder(8)]
    public string CardText { get; set; } = string.Empty;

    [JsonPropertyOrder(9)]
    public string Power { get; set; } = string.Empty;

    [JsonPropertyOrder(10)]
    public string Toughness { get; set; } = string.Empty;

    [JsonPropertyOrder(11)]
    public bool HasPowerAndToughness => !string.IsNullOrEmpty(Power) || !string.IsNullOrEmpty(Toughness);

    [JsonPropertyOrder(12)]
    public string Rarity { get; set; } = string.Empty;

    [JsonPropertyOrder(13)]
    public int FontSize { get; set; } = 11;

    public int CompareTo(Card? other)
    {
        return comparer.Compare(this, other);
    }
}

public class ScryfallReferenceComparer : IComparer<Card>
{
    public int Compare(Card? x, Card? y)
    {
        return string.Compare(x?.ScryfallReference, y?.ScryfallReference);
    }
}

public class CardColorComparer : IComparer<Card>
{
    Dictionary<string, int> values = new();

    public CardColorComparer()
    {
        values = CardColors.Colors
            .Select((_, index) => (index, value: _.Value))
            .ToDictionary(_ => _.value, _ => _.index);
    }

    public int Compare(Card? x, Card? y)
    {
        var indexX = GetColorIndex(x);
        var indexY = GetColorIndex(y);

        var valueX = values[indexX];
        var valueY = values[indexY];

        if (valueX > valueY) return 1;
        if (valueX < valueY) return -1;
        return 0;
    }

    private string GetColorIndex(Card? x)
    {
        var cost = x?.ManaCost
            .Where(_ => "WUBRG".Contains(_))
            .Distinct()
            .ToList();

        return cost switch
        {
            null => values.Keys.First(),
            var c when c.Count == 1 && "WUBRG".Contains(c[0]) => c[0].ToString(),
            var c when c.Count > 1 => "M",
            var c when c.Count == 0 && (x?.Types.Contains("Land") ?? false) => "L",
            var c when c.Count == 0 && !(x?.Types.Contains("Land") ?? false) => "0",
            _ => values.Keys.First()
        };
    }
}