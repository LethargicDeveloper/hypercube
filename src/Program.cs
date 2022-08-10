using Microsoft.Extensions.DependencyInjection;
using Hypercube.Scryfall;
using Hypercube.UrzasAI;

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
        services.AddScoped<CardSymbolProvider>();

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

        services.AddHttpClient<UrzasAIClient>(client =>
            client.BaseAddress = new Uri("http://backend-dot-valued-sight-253418.ew.r.appspot.com/api/v1/"));

        services.AddSingleton(provider =>
        {
            var scryfallClient = provider.GetRequiredService<ScryfallClient>();
            return CubeManager.Create(scryfallClient);
        });
    }
}