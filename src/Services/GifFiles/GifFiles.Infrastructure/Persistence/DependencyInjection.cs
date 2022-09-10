using GifFiles.Application.Interfaces;
using GifFiles.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Poppers.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddSingleton<IGifFileReader, GifFileReader>();
        services.AddSingleton<IGifFileWriter, GifFileWriter>();
        
        return services;
    }
}