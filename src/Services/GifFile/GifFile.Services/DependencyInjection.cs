using GifFile.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GifFile.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IGifFileGenerator, GifFileGenerator>();
        return services;
    }
}