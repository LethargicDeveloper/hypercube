using RestSharp;
using System.Text.Json;

namespace Hypercube.Scryfall;

public class ScryfallClient
{
    readonly RestClient client;

    public ScryfallClient(HttpClient client)
    {
        this.client = new RestClient(client);
    }

    public IEnumerable<Expansion> GetExpansions(bool reload = false)
    {
        if (reload || !TryLoadCache("expansions", out List<Expansion>? expansions))
        {
            var request = new RestRequest("sets");
            var result = this.client.Get<ScryfallResponse<Expansion>>(request);
            expansions = result?.Data?
                .OrderBy(_ => _.Name)
                .Select(_ => new Expansion
                {
                    Name = _.Name,
                    Code = _.Code,
                    SearchUri = _.SearchUri.Replace("unique=prints", "unique=cards")
                })
                .ToList();

            SaveCache("expansions", expansions);
        }

        return expansions ?? Enumerable.Empty<Expansion>();
    }

    public IEnumerable<CardSymbol> GetSymbols(bool reload = false)
    {
        if (reload || !TryLoadCache("symbology", out List<CardSymbol>? cardSymbols))
        {
            var request = new RestRequest("symbology");
            var result = this.client.Get<ScryfallResponse<CardSymbol>>(request);
            cardSymbols = result?.Data?.ToList();
            SaveCache("symbology", cardSymbols);
        }

        return cardSymbols ?? Enumerable.Empty<CardSymbol>();
    }

    public string? GetSymbol(string url)
    {
        var request = new RestRequest(url);
        var response = this.client.Get(request);
        return response?.Content;
    }

    public IEnumerable<ScryfallCard> GetCardsForCube(Cube cube, bool reload = false)
    {
        if (reload || !TryLoadCache($"{cube.ExpansionCode}", out List<ScryfallCard>? cards))
        {
            cards = new List<ScryfallCard>();

            string scryfallUri = cube.ScryfallUri;
            ScryfallResponse<ScryfallCard>? result;

            do
            {
                var request = new RestRequest(scryfallUri);
                result = this.client.Get<ScryfallResponse<ScryfallCard>>(request);
                if (result?.Data == null) return Enumerable.Empty<ScryfallCard>();

                cards.AddRange(result.Data);

                if (result.HasMore)
                {
                    scryfallUri = result.NextPage;
                }

                Thread.Sleep(200);
            } while (result.HasMore);

            SaveCache(cube.ExpansionCode, cards);
        }

        cards = cards?
            .OrderBy(_ => _, new ScryfallCardColorComparer())
            .ThenBy(_ => _.Name)
            .Where(_ => !_.Variation)
            .ToList();

        return cards ?? Enumerable.Empty<ScryfallCard>();
    }

    bool TryLoadCache<T>(string key, out T? data)
    {
        var filename = $".\\Cache\\{key}.cache";
        if (!File.Exists(filename))
        {
            data = default;
            return false;
        }

        var json = File.ReadAllText(filename);
        data = JsonSerializer.Deserialize<T>(json);
        return true;
    }

    void SaveCache<T>(string key, T data)
    {
        if (data == null) return;

        if (!Directory.Exists("Cache"))
        {
            Directory.CreateDirectory("Cache");
        }

        var json = JsonSerializer.Serialize(data);
        File.WriteAllText($".\\Cache\\{key}.cache", json);
    }
}
