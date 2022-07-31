using Microsoft.Extensions.DependencyInjection;
using Screenshots.Browser.Interfaces;
using Screenshots.Browser.Options;

namespace Screenshots.Browser;

public static class DependencyInjection
{
    // public static IServiceCollection AddBrowser(this IServiceCollection services)
    // {
    //     services.AddBrowserServices();
    //     services.Configure();
    //     return services;
    // }

    public static IServiceCollection AddBrowser(this IServiceCollection services,
        Action<BrowserPoolOptions> options)
    {
        services.AddBrowserServices();
        services.Configure(options);
        return services;
    }

    private static IServiceCollection AddBrowserServices(this IServiceCollection services)
    {
        services.AddSingleton<IBrowserExecutor, BrowserExecutor>();
        services.AddSingleton<IBrowserFactory, BrowserFactory>();
        services.AddSingleton<IBrowserPool, BrowserPool>();
        return services;
    }
}