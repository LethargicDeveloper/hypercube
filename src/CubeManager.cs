using System.Text.Json;

namespace Hypercube;

public class CubeManager
{
    const string BaseDir = "Cubes";

    private CubeManager() { }

    public static CubeManager Create()
    {
        if (!Directory.Exists(BaseDir))
        {
            Directory.CreateDirectory(BaseDir);
        }

        return new CubeManager();
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

        var json = JsonSerializer.Serialize(cube);
        File.WriteAllText(Path.Combine(path, "cube.json"), json);

        // TODO: create scryfall.json of all cards in the set

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
}
