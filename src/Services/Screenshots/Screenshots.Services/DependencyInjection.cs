using Microsoft.Extensions.DependencyInjection;
using Screenshots.Services.Interfaces;

namespace Screenshots.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection service)
    {
        service.AddSingleton<IScreenshotService, ScreenshotService>();
        return service;
    }
}