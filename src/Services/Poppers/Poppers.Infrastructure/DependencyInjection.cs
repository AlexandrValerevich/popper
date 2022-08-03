using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poppers.Application.Gif.Commands;
using Poppers.Application.Gif.Interfaces;
using Poppers.Infrastructure.Gif.Services;
using Shared.Common;
using Shared.GifFiles;
using Shared.Screenshots;

namespace Poppers.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddScoped<IScreenshotCreator, ScreenshotCreator>();
        services.AddScoped<IGifCreator, GifCreator>();
        services.AddScoped<IGifReader, GifReader>();
        services.AddScoped<IGifRemover, GifRemover>();

        services.AddScreenshotClient(options =>
        {
            options.BaseUrl = config.GetValue<string>("Clients:Screenshots:BaseUrl");
            options.Retry = config.GetValue<int>("Clients:Screenshots:MaxRetryAmount");
        });

        services.AddGifFileClient(options =>
        {
            options.BaseUrl = config.GetValue<string>("Clients:GifFiles:BaseUrl");
            options.MaxRetryAmount = config.GetValue<int>("Clients:GifFiles:MaxRetryAmount");
        });

        services.AddLogErrorBehavior();
        services.AddValidationBehavior();
        return services;
    }
}