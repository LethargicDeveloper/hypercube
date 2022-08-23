namespace Hypercube;

public static class CardColors
{
    public static List<CardColorItem> Colors = new()
    {
        new CardColorItem { Name = "White", Value = "W" },
        new CardColorItem { Name = "Blue", Value = "U" },
        new CardColorItem { Name = "Black", Value = "B" },
        new CardColorItem { Name = "Red", Value = "R" },
        new CardColorItem { Name = "Green", Value = "G" },
        new CardColorItem { Name = "Multicolored", Value = "M" },
        new CardColorItem { Name = "Colorless", Value = "0" },
        new CardColorItem { Name = "Lands", Value = "L" }
    };
}

public record CardColorItem
{
    public string Name { get; init; } = string.Empty;
    public string Value { get; init; } = string.Empty;
}