using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Screenshots.Application.Interfaces;
using Screenshots.Infrastructure.Browser;
using Screenshots.Infrastructure.Services;
using Shared.Common;
using Shared.GifFiles.Policies;

namespace Screenshots.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddSingleton<IScreenshotGenerator, ScreenshotGenerator>();
        
        services.AddPolicies();
        services.AddBrowser(config);

        services.AddValidationBehavior();
        return services;
    }
}