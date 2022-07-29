using Microsoft.Extensions.DependencyInjection;
using Poppers.Application.Gif.Interfaces;
using Poppers.Browser;
using Poppers.Infrastructure.Gif.Services;

namespace Poppers.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddBrowser((options) =>
        {
            options.MaxAmountBrowser = 1;
            options.MaxBrowserIdleMinutes = 5;
        });
        services.AddScoped<IScreenshotCreator, ScreenshotCreator>();
        services.AddScoped<IGifFileGenerator, GifFileGenerator>();

        return services;
    }
}