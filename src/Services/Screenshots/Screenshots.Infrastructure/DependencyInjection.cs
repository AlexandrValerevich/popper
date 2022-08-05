using Microsoft.Extensions.DependencyInjection;
using Screenshots.Application.Interfaces;
using Screenshots.Browser;
using Screenshots.Infrastructure.Helpers;
using Shared.Common;
using Shared.GifFiles.Policies;

namespace Screenshots.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IScreenshotGenerator, ScreenshotGenerator>();
        
        services.AddPolicies();
        services.AddBrowser();

        services.AddValidationBehavior();
        return services;
    }
}