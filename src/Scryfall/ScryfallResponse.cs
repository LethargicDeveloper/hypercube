namespace Hypercube.Scryfall;

public class ScryfallResponse<T>
{
    public bool HasMore { get; set; }
    public List<T>? Data { get; set; }
}
