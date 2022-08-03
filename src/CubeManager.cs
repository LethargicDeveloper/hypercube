using Hypercube.Scryfall;
using System.Text.Json;

namespace Hypercube;

public class CubeManager
{
    const string BaseDir = "Cubes";

    readonly ScryfallClient scryfall;

    private CubeManager(ScryfallClient scryfall)
    {
        this.scryfall = scryfall;
    }

    public static CubeManager Create(ScryfallClient scryfall)
    {
        if (!Directory.Exists(BaseDir))
        {
            Directory.CreateDirectory(BaseDir);
        }

        return new CubeManager(scryfall);
    }

    public IEnumerable<string> GetCubes()
    {
        return Directory.GetDirectories(BaseDir);
    }

    public bool CreateCube(Cube cube)
    {
        var path = Path.Combine(BaseDir, cube.CubeName);
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
        var path = Path.Combine(BaseDir, cubeName);
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
