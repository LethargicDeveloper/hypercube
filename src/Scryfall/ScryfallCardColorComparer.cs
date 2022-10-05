namespace Hypercube.Scryfall;

public class ScryfallCardColorComparer : IComparer<ScryfallCard>
{
    Dictionary<string, int> values = new();

    public ScryfallCardColorComparer()
    {
        values = CardColors.Colors
            .Select((_, index) => (index, value: _.Value))
            .ToDictionary(_ => _.value, _ => _.index);
    }

    public int Compare(ScryfallCard? x, ScryfallCard? y)
    {
        var indexX = GetColorIndex(x);
        var indexY = GetColorIndex(y);

        var valueX = values[indexX];
        var valueY = values[indexY];

        if (valueX > valueY) return 1;
        if (valueX < valueY) return -1;
        return 0;
    }

    public string GetColorIndex(ScryfallCard? x)
    {
        return x?.Colors switch
        {
            null => values.Keys.First(),
            var c when c.Count == 1 && "WUBRG".Contains(c[0]) => c[0],
            var c when c.Count > 1 => "M",
            var c when c.Count == 0 && (x?.TypeLine.Contains("Land") ?? false) => "L",
            var c when c.Count == 0 && !(x?.TypeLine.Contains("Land") ?? false) => "0",
            _ => values.Keys.First()
        };
    }
}