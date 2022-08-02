using System.Text.Json.Serialization;

namespace Hypercube.Scryfall;

public class Expansion
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("search_uri")]
    public string SearchUri { get; set; } = string.Empty;
}
