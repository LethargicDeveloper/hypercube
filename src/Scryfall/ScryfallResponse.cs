using System.Text.Json.Serialization;

namespace Hypercube.Scryfall;

public class ScryfallResponse<T>
{
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
    [JsonPropertyName("next_page")]
    public string NextPage { get; set; } = string.Empty;
    public List<T>? Data { get; set; }
}
