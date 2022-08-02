using Microsoft.Extensions.DependencyInjection;

namespace Hypercube;

public class FormFactory
{
    readonly IServiceProvider provider;

    public FormFactory(IServiceProvider provider)
    {
        this.provider = provider;
    }

    public T Create<T>()
        where T : Form
    {
        return this.provider.GetRequiredService<T>();
    }
}
