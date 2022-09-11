using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Screenshots.Infrastructure.Browser.Interfaces;

namespace Screenshots.Infrastructure.Browser;

public static class DependencyInjection
{
    public static IServiceCollection AddBrowser(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddSingleton<IBrowserExecutor, BrowserExecutor>();
        services.AddSingleton<IBrowserFactory, BrowserFactory>();
        services.AddSingleton<IBrowserPool, BrowserPool>();

        services.Configure<BrowserSettings>(config.GetSection(BrowserSettings.SectionName));
        return services;
    }
}