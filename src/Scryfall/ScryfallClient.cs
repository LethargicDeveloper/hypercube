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
        if (reload || !TryLoadCache("expansions", out IEnumerable<Expansion>? expansions))
        {
            var request = new RestRequest("sets");
            var result = this.client.Get<ScryfallResponse<Expansion>>(request);
            expansions = result?.Data?.OrderBy(_ => _.Name);
            SaveCache("expansions", expansions);
        }

        return expansions ?? Enumerable.Empty<Expansion>();
    }

    bool TryLoadCache<T>(string key, out T? data)
    {
        var filename = $"{key}.cache";
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

        var json = JsonSerializer.Serialize(data);
        File.WriteAllText($"{key}.cache", json);
    }
}
