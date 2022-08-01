using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poppers.Application.Gif.Interfaces;
using Poppers.Infrastructure.Gif.Services;
using Shared.GifFile;
using Shared.Screenshots;

namespace Poppers.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddScoped<IScreenshotCreator, ScreenshotCreator>();
        services.AddScoped<IGifFileGenerator, GifFileGenerator>();

        services.AddScreenshotClient(options =>
        {
            options.BaseUrl = config.GetValue<string>("Clients:Screenshots:BaseUrl");
            options.MaxRetryAmount = config.GetValue<int>("Clients:Screenshots:MaxRetryAmount");
        });

        services.AddGifFileClient(options =>
        {
            options.BaseUrl = config.GetValue<string>("Clients:GifFiles:BaseUrl");
            options.MaxRetryAmount = config.GetValue<int>("Clients:GifFiles:MaxRetryAmount");
        });

        return services;
    }
}