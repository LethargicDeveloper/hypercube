using Hypercube.Scryfall;
using Svg;
using System.Text.RegularExpressions;

namespace Hypercube;

public class CardSymbolProvider
{
    const string Extension = ".png";

    readonly ScryfallClient client;
    Dictionary<string, CardSymbol> cardSymbols = new();

    public CardSymbolProvider(ScryfallClient client)
    {
        this.client = client;
        LoadSymbols();
    }

    public ICollection<string> GetCardSymbolImagePaths(string text)
    {
        var imagePaths = new List<string>();
        var matches = Regex.Matches(text.ToUpper(), "{.+?}");
        foreach (Match match in matches)
        {
            if(cardSymbols.TryGetValue(match.Value, out var symbol))
            {
                var filename = match.Value.Replace("/", "-");
                filename = string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));

                var path = $".\\img\\symbols\\{filename}";
                if (!File.Exists($"{path}{Extension}"))
                {
                    var svg = this.client.GetSymbol(symbol.SvgUri);
                    File.WriteAllText($"{path}.svg", svg);
                    var doc = SvgDocument.Open($"{path}.svg");
                    doc.Width = 15;
                    doc.Height = 15;
                    var img = doc.Draw();
                    img?.Save($"{path}{Extension}");
                    File.Delete($"{path}.svg");

                    while (!File.Exists($"{path}{Extension}"))
                    {
                        Thread.Sleep(10);
                    }
                }

                imagePaths.Add($"{path}{Extension}");
            }
        }

        return imagePaths;
    }

    public string GetCardSymbolImagePath(string text)
    {
        return GetCardSymbolImagePaths(text).FirstOrDefault() ?? string.Empty;
    }

    void LoadSymbols()
    {
        if (this.cardSymbols.Count == 0)
        {
            this.cardSymbols = this.client.GetSymbols().ToDictionary(_ => _.Symbol.ToUpper());
        }

        if (!Directory.Exists(".\\img\\symbols\\"))
        {
            Directory.CreateDirectory(".\\img\\symbols\\");
        }
    }
}
