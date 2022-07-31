using Microsoft.Extensions.DependencyInjection;

namespace Hypercube;

public class FormNavigation
{
    readonly IServiceProvider provider;

    public FormNavigation(IServiceProvider provider)
    {
        this.provider = provider;
    }

    public void Show<T>()
        where T : Form
    {
        this.provider.GetRequiredService<T>().Show();
    }

    public void ShowDialog<T>()
        where T : Form
    {
        this.provider.GetRequiredService<T>().ShowDialog();
    }
}
