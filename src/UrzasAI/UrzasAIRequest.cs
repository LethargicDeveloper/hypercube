using System.Text.Json.Serialization;

namespace Hypercube.UrzasAI;

public class UrzasAIRequest
{
    [JsonPropertyName("presets")]
    public CardText Presets { get; set; } = new CardText();
    [JsonPropertyName("deckBuilder")]
    public bool DeckBuilder { get; set; }
    [JsonPropertyName("temperature")]
    public int Temperature { get; set; } = 5;
}
