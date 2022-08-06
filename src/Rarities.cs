using Hypercube.Scryfall;

namespace Hypercube;

public static class Rarities
{
    static readonly Dictionary<string, string> rarities = new()
    {
        { "Common", "gear_common.png" },
        { "Uncommon", "gear_uncommon.png" },
        { "Rare", "gear_rare.png" },
        { "Mythic", "gear_mythic.png" }
    };

    public static string GetIconPath(string rarity)
    {
        if (rarities.TryGetValue(rarity, out var val))
        {
            return val;
        }

        return "gear_common.png";
    }

    public static string GetRarity(string rarity)
    {
        return rarities.Keys.FirstOrDefault(_ => string.Equals(rarity, _, StringComparison.OrdinalIgnoreCase))
            ?? "Common";
    }
}