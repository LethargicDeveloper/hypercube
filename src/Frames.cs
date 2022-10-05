namespace Hypercube;

public static class Frames
{
    static readonly Dictionary<string, (string desc, string path)> frames = new()
    {
        { "", ("Colorless", "0.png") },
        { "L", ("Colorless (Legendary)", "0L.png") },
        { "W", ("White", "W.png") },
        { "WL", ("White (Legendary)", "WL.png") },
        { "WA", ("White Artifact", "WA.png") },
        { "U", ("Blue", "U.png") },
        { "UL", ("Blue (Legendary)", "UL.png") },
        { "UA", ("Blue Artifact", "UA.png") },
        { "B", ("Black", "B.png") },
        { "BL", ("Black (Legendary)", "BL.png") },
        { "BA", ("Black Artifact", "BA.png") },
        { "R", ("Red", "R.png") },
        { "RL", ("Red (Legendary)", "RL.png") },
        { "RA", ("Red Artifact", "RA.png") },
        { "G", ("Green", "G.png") },
        { "GL", ("Green (Legendary)", "GL.png") },
        { "GA", ("Green Artifact", "GA.png") },
        { "BW", ("White/Black", "BW.png") },
        { "BWL", ("White/Black (Legendary)", "BWL.png") },
        { "UW", ("White/Blue", "UW.png") },
        { "UWL", ("White/Blue (Legendary)", "UWL.png") },
        { "BU", ("Blue/Black", "BU.png") },
        { "BUL", ("Blue/Black (Legendary)", "BUL.png") },
        { "RU", ("Blue/Red", "RU.png") },
        { "RUL", ("Blue/Red (Legendary)", "RUL.png") },
        { "BG", ("Black/Green", "BG.png") },
        { "BGL", ("Black/Green (Legendary)", "BGL.png") },
        { "BR", ("Black/Red", "BR.png") },
        { "BRL", ("Black/Red (Legendary)", "BRL.png") },
        { "GR", ("Red/Green", "GR.png") },
        { "GRL", ("Red/Green (Legendary)", "GRL.png") },
        { "RW", ("Red/White", "RW.png") },
        { "RWL", ("Red/White (Legendary)", "RWL.png") },
        { "GW", ("Green/White", "GW.png") },
        { "GWL", ("Green/White (Legendary)", "GWL.png") },
        { "GU", ("Green/Blue", "GU.png") },
        { "GUL", ("Green/Blue (Legendary)", "GUL.png") },
        { "M", ("Gold", "M.png") },
        { "ML", ("Gold (Legendary)", "ML.png") },
        { "MA", ("Gold Artifact", "MA.png") },
        { "A", ("Artifact", "A.png") },
        { "AL", ("Artifact (Legendary)", "AL.png") },
        { "Land", ("Land", "Land.png") },
    };

    public static Frame GetFrameForCard(Scryfall.ScryfallCard card)
    {
        string key = card.TypeLine.Contains("Land")
            ? "Land" : string.Join("", card.Colors.OrderBy(_ => _)).ToUpper();

        if (card.TypeLine.Contains("Artifact"))
        {
            key += "A";
        }
        else if (card.TypeLine.Contains("Legendary"))
        {
            key += "L";
        }

        var isLand = card.TypeLine.Contains("Land");
        var isArtifact = card.TypeLine.Contains("Artifact");
        var isEnchantment = card.TypeLine.Contains("Enchantment");
        var isLegendary = card.TypeLine.Contains("Legendary");
        var isMultiColored = card.Colors.Count > 1;

        if (!frames.ContainsKey(key))
        {
            if (isLand) key = "Land";
            else if (isMultiColored)
            {
                key = $"M";
                if (isArtifact) key += "A";
                else if (isLegendary) key += "L";
            }
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
