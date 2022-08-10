using System.Text.Json.Serialization;

namespace Hypercube.UrzasAI;

// TODO: figure out what the Urza's AI syntax is for the various mana symbols

public class CardText
{
    [JsonPropertyName("deck_name")]
    public string DeckName { get; set; } = string.Empty;
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("manaCost")]
    public string ManaCost { get; set; } = string.Empty;
    [JsonPropertyName("types")]
    public string Types { get; set; } = string.Empty;
    [JsonPropertyName("subtypes")]
    public string Subtypes { get; set; } = string.Empty;
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
    [JsonPropertyName("power")]
    public string Power { get; set; } = string.Empty;
    [JsonPropertyName("toughness")]
    public string Toughness { get; set; } = string.Empty;
    [JsonPropertyName("flavorText")]
    public string FlavorText { get; set; } = string.Empty;
    [JsonPropertyName("rarity")]
    public string Rarity { get; set; } = string.Empty;
    [JsonPropertyName("loyalty")]
    public string Loyalty { get; set; } = string.Empty;
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
    [JsonPropertyName("basic_land")]
    public string BasicLand { get; set; } = string.Empty;

}
