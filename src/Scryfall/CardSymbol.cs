using System.Text.Json.Serialization;

namespace Hypercube.Scryfall;

public class CardSymbol
{
    public string Symbol { get; set; } = string.Empty;
    [JsonPropertyName("svg_uri")]
    public string SvgUri { get; set; } = string.Empty;
}
