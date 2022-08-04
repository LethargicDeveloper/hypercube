using Hypercube.Scryfall;

namespace Hypercube;

public class Frames
{
    static Dictionary<string, (string desc, string path)> frames = new()
    {
        { "w", ("White", "w.png") }
    };

    public static string GetFramePath(Card card)
    {
        var key = string.Join("", card.Colors.OrderBy(_ => _));

        if (frames.TryGetValue(key, out var val))
        {
            return val.path;
        }

        return "w.png";
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

    public static string GetDefaultFrame() => "White";
}

public class Frame
{
    public string Key { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
}
