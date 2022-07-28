using Microsoft.Extensions.DependencyInjection;
using Poppers.Infrastructure.Browser.Interfaces;

namespace Poppers.Infrastructure.Browser;

public static class DependencyInjection
{
    public static IServiceCollection AddBrowser(this IServiceCollection services)
    {
        services.AddSingleton<IBrowserExecutor, BrowserExecutor>();
        services.AddSingleton<IBrowserFactory, BrowserFactory>();
        services.AddSingleton<IBrowserPool, BrowserPool>();

        return services;
    }
}