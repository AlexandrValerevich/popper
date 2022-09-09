using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poppers.Infrastructure.Authentication;
using Poppers.Infrastructure.Gif;
using Poppers.Infrastructure.Persistence;
using Shared.Common;
using Shared.GifFiles;
using Shared.Screenshots;

namespace Poppers.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddAuth(config);
        services.AddGif();
        services.AddPersistence(config);

        services.AddScreenshotClient(options =>
        {
            options.BaseUrl = config.GetValue<string>("Clients:Screenshots:BaseUrl");
            options.Retry = config.GetValue<int>("Clients:Screenshots:MaxRetryAmount");
        });

        services.AddGifFileClient(options =>
        {
            options.BaseUrl = config.GetValue<string>("Clients:GifFiles:BaseUrl");
            options.Retry = config.GetValue<int>("Clients:GifFiles:MaxRetryAmount");
        });

        services.AddValidationBehavior();
        return services;
    }
}