using Microsoft.Extensions.DependencyInjection;
using Screenshots.Application.Interfaces;
using Screenshots.Application.Services;

namespace Screenshots.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddSingleton<IScreenshotService, ScreenshotService>();
        return service;
    }
}