using System.Text.Json;

namespace Hypercube;

public class Cube
{
    const string BaseDir = "Cubes";

    public string CubeName { get; init; } = string.Empty;
    public string ScryfallUri { get; init; } = string.Empty;
    public string Expansion { get; init; } = string.Empty;
    public string ExpansionCode { get; init; } = string.Empty;
    public List<Card> Cards { get; set; } = new();

    public void AddOrUpdate(Card card)
    {
        var existingCard = Cards.FirstOrDefault(_ => _.ScryfallReference == card.ScryfallReference);
        if (existingCard != null)
        {
            Cards.Remove(existingCard);
        }
        
        Cards.Add(card);
    }

    public void Save()
    {
        var path = Path.Combine(BaseDir, CubeName);
        var json = JsonSerializer.Serialize(this);
        File.WriteAllText(Path.Combine(path, "cube.json"), json);
    }

    public void SaveArtImage(string scryfallReference, Image image)
    {
        var path = Path.Combine(BaseDir, CubeName, $"art_{GetDeterministicHashCode(scryfallReference)}.png");
        image.Save(path);
    }

    public void SaveCardImage(string scryfallReference, Image image)
    {
        var path = Path.Combine(BaseDir, CubeName, $"card_{GetDeterministicHashCode(scryfallReference)}.png");
        image.Save(path);
    }

    int GetDeterministicHashCode(string str)
    {
        unchecked
        {
            int hash1 = (5381 << 16) + 5381;
            int hash2 = hash1;

            for (int i = 0; i < str.Length; i += 2)
            {
                hash1 = ((hash1 << 5) + hash1) ^ str[i];
                if (i == str.Length - 1)
                    break;
                hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
            }

            return hash1 + (hash2 * 1566083941);
        }
    }
}

public class Card
{
    public string ScryfallReference { get; init; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ManaCost { get; set; } = string.Empty;
    public string Frame { get; set; } = string.Empty;
    public List<string> Supertypes { get; set; } = new();
    public List<string> Types { get; set; } = new();
    public List<string> Subtypes { get; set; } = new();
    public string CardText { get; set; } = string.Empty;
    public string Power { get; set; } = string.Empty;
    public string Toughness { get; set; } = string.Empty;
    public bool HasPowerAndToughness => !string.IsNullOrEmpty(Power) || !string.IsNullOrEmpty(Toughness);
    public string Rarity = string.Empty;
    public int FontSize = 0;
}
