using Microsoft.Extensions.DependencyInjection;
using Hypercube.Scryfall;

namespace Hypercube;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();
        ConfigureServices(services);

        using var provider = services.BuildServiceProvider();
        var mainForm = provider.GetRequiredService<MainForm>();

        Application.Run(mainForm);
    }

    static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<FormFactory>();

        var forms =
            from type in typeof(Program).Assembly.GetExportedTypes()
            where type.IsAssignableTo(typeof(Form))
            select type;

        foreach (var type in forms)
        {
            services.AddTransient(type);
        }

        services.AddHttpClient<ScryfallClient>(client =>
            client.BaseAddress = new Uri("https://api.scryfall.com/"));

        services.AddSingleton(CubeManager.Create());
    }
}