using System.Text.Json.Serialization;

namespace Hypercube.Scryfall;

public class Expansion
{
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("search_uri")]
    public string SearchUri { get; init; } = string.Empty;
}
