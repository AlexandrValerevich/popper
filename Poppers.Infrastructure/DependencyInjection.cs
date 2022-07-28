using Microsoft.Extensions.DependencyInjection;
using Poppers.Application.Gif.Interfaces;
using Poppers.Infrastructure.Browser;
using Poppers.Infrastructure.Gif.Services;

namespace Poppers.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddBrowser();
        services.AddScoped<IScreenshotCreator, ScreenshotCreator>();
        
        return services;
    }
}