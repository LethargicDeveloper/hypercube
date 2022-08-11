namespace Hypercube;

public static class Frames
{
    static readonly Dictionary<string, (string desc, string path)> frames = new()
    {
        { "", ("Colorless", "0.png") },
        { "L", ("Colorless (Legendary)", "0L.png") },
        { "W", ("White", "W.png") }
    };

    public static Frame GetFrameForCard(Scryfall.Card card)
    {
        var key = string.Join("", card.Colors.OrderBy(_ => _)).ToUpper();

        if (card.TypeLine.Contains("Legendary"))
        {
            key += "L";
        }

        if (frames.TryGetValue(key, out var val))
        {
            return new()
            {
                Key = key,
                Description = val.desc,
                Path = val.path
            };
        }

        return new()
        {
            Key = "",
            Description = "Colorless",
            Path = "0.png"
        };
    }

    public static List<Frame> GetFrames()
    {
        return frames.Select(_ => new Frame
        {
            Key = _.Key,
            Description = _.Value.desc,
            Path = _.Value.path
        }).ToList();
    }
}

public class Frame
{
    public string Key { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
}
