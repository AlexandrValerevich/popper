using Microsoft.Extensions.DependencyInjection;
using Poppers.Infrastructure.Browser.Interfaces;
using Poppers.Infrastructure.Browser.Options;

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

    public static IServiceCollection AddBrowser(this IServiceCollection services,
        Action<BrowserPoolOption> options = null)
    {
        services.AddSingleton<IBrowserExecutor, BrowserExecutor>();
        services.AddSingleton<IBrowserFactory, BrowserFactory>();
        services.AddSingleton<IBrowserPool, BrowserPool>();

        services.Configure(options);
        return services;
    }
}