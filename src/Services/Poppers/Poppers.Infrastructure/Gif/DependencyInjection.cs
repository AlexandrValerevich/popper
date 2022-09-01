using Microsoft.Extensions.DependencyInjection;
using Poppers.Application.Common.Interfaces.Gif;

namespace Poppers.Infrastructure.Gif;

public static class DependencyInjection
{
    public static IServiceCollection AddGif(this IServiceCollection services)
    {
        services.AddScoped<IScreenshotCreator, ScreenshotCreator>();
        return services;
    }
}