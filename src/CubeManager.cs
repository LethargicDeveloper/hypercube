using Hypercube.Scryfall;
using System.Text.Json;

namespace Hypercube;

public class CubeManager
{
    readonly ScryfallClient scryfall;
    readonly Settings settings;
    
    string? workingDirectory;

    private CubeManager(ScryfallClient scryfall, Settings settings)
    {
        this.scryfall = scryfall;
        this.settings = settings;
    }

    string CubeDirectory => this.workingDirectory ?? this.settings.CubeLocation;

    public static CubeManager Create(ScryfallClient scryfall, Settings settings)
    {
        if (!Directory.Exists(settings.CubeLocation))
        {
            Directory.CreateDirectory(settings.CubeLocation);
        }

        return new CubeManager(scryfall, settings);
    }

    public void SetWorkingDirectory(string? path)
    {
        this.workingDirectory = path;
    }

    public IEnumerable<string> GetCubes()
    {
        return Directory.GetDirectories(CubeDirectory);
    }

    public bool CreateCube(Cube cube)
    {
        var path = Path.Combine(CubeDirectory, cube.CubeName);
        if (Directory.Exists(path))
        {
            return false;
        }

        Directory.CreateDirectory(path);

        cube.Save();
        CreateScryfallCache(cube);

        return true;
    }

    public Cube? LoadCube(string cubeName)
    {
        var path = Path.Combine(CubeDirectory, cubeName);
        if (!Directory.Exists(path)) return null;

        if (File.Exists(Path.Combine(path, "cube.json")))
        {
            var cubePath = Path.Combine(path, "cube.json");
            var json = File.ReadAllText(cubePath);
            var cube = JsonSerializer.Deserialize<Cube>(json);

            cube?.Save();

            File.Delete(cubePath);
            return cube;
        }
        else if (File.Exists(Path.Combine(path, "config.json")))
        {
            var json = File.ReadAllText(Path.Combine(path, "config.json"));
            var cube = JsonSerializer.Deserialize<Cube>(json);

            foreach (var file in Directory.GetFiles(path)
                .Where(_ => Path.GetExtension(_) == ".json")
                .Where(_ => Path.GetFileName(_) != "config.json"))
            {
                json = File.ReadAllText(Path.Combine(path, file));
                var cards = JsonSerializer.Deserialize<Card[]>(json)?.ToList();

                if (cards != null)
                {
                    cube?.Cards.AddRange(cards);
                }
            }

            return cube;
        }

        return null;
    }

    void CreateScryfallCache(Cube cube)
    {
        this.scryfall.GetCardsForCube(cube);
    }
}
