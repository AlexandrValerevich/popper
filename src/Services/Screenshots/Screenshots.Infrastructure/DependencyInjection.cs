using Microsoft.Extensions.DependencyInjection;
using Screenshots.Application.Interfaces;
using Screenshots.Browser;
using Screenshots.Infrastructure.Helpers;

namespace Screenshots.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IScreenshotGenerator, ScreenshotGenerator>();
        services.AddBrowser((options) =>
        {
            options.MaxAmountBrowser = 2;
            options.MaxBrowserIdleMinutes = 1;
        });
        return services;
    }
}