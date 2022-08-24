using Hypercube.Scryfall;
using System.Text.Json;

namespace Hypercube;

public class CubeManager
{
    readonly ScryfallClient scryfall;
    readonly Settings settings;

    private CubeManager(ScryfallClient scryfall, Settings settings)
    {
        this.scryfall = scryfall;
        this.settings = settings;
    }

    public static CubeManager Create(ScryfallClient scryfall, Settings settings)
    {
        if (!Directory.Exists(settings.CubeLocation))
        {
            Directory.CreateDirectory(settings.CubeLocation);
        }

        return new CubeManager(scryfall, settings);
    }

    public IEnumerable<string> GetCubes()
    {
        return Directory.GetDirectories(this.settings.CubeLocation);
    }

    public bool CreateCube(Cube cube)
    {
        var path = Path.Combine(this.settings.CubeLocation, cube.CubeName);
        if (Directory.Exists(path))
        {
            return false;
        }

        Directory.CreateDirectory(path);

        CreateCubeConfig(path, cube);
        CreateScryfallCache(path, cube);

        return true;
    }

    public Cube? LoadCube(string cubeName)
    {
        var path = Path.Combine(this.settings.CubeLocation, cubeName);
        if (!Directory.Exists(path))
        {
            return null;
        }    

        var json = File.ReadAllText(Path.Combine(path, "cube.json"));
        return JsonSerializer.Deserialize<Cube>(json);
    }

    void CreateCubeConfig(string path, Cube cube)
    {
        var json = JsonSerializer.Serialize(cube);
        File.WriteAllText(Path.Combine(path, "cube.json"), json);
    }

    void CreateScryfallCache(string path, Cube cube)
    {
        this.scryfall.GetCardsForCube(cube);
    }
}
