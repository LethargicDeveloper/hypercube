using System.Text.Json.Serialization;

namespace Hypercube.Scryfall;

public class ScryfallCard
{
    [JsonPropertyName("object")]
    public string Object { get; init; } = string.Empty;
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;
    [JsonPropertyName("lang")]
    public string Language { get; init; } = string.Empty;
    [JsonPropertyName("image_uris")]
    public ImageUri ImageUris { get; init; } = new();
    [JsonPropertyName("mana_cost")]
    public string ManaCost { get; init; } = string.Empty;
    [JsonPropertyName("type_line")]
    public string TypeLine { get; init; } = string.Empty;
    [JsonPropertyName("power")]
    public string Power { get; init; } = string.Empty;
    [JsonPropertyName("toughness")]
    public string Toughness { get; init; } = string.Empty;
    [JsonPropertyName("all_parts")]
    public List<AllParts> AllParts { get; init; } = new();
    [JsonPropertyName("legalities")]
    public Legalities Legalities { get; init; } = new();
    [JsonPropertyName("collector_number")]
    public string CollectorNumber { get; init; } = string.Empty;
    [JsonPropertyName("rarity")]
    public string Rarity { get; init; } = string.Empty;
    [JsonPropertyName("variation")]
    public bool Variation { get; init; }
    [JsonPropertyName("colors")]
    public List<string> Colors { get; init; } = new();
}

public class ImageUri
{
    public string Normal { get; init; } = string.Empty;
}

public class AllParts
{
    public string Object { get; init; } = string.Empty;
    public string Component { get; init; } = string.Empty;
    public string Uri { get; init; } = string.Empty;
}

public class Legalities
{
    public string Commander { get; init; } = string.Empty;
}