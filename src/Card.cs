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

    public string GetColorIndex(Card? x)
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