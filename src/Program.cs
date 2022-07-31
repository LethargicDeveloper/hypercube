using Microsoft.Extensions.DependencyInjection;

namespace MyFirstWinFormsApp;

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
        services.AddScoped<MainForm>();
    }
}