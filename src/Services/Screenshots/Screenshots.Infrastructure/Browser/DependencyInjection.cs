using Microsoft.Extensions.DependencyInjection;
using Screenshots.Browser.Interfaces;

namespace Screenshots.Browser;

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