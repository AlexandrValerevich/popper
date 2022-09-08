using GifFiles.Application.Interfaces;
using GifFiles.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poppers.Infrastructure.Persistence.EF;

namespace Poppers.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddSingleton<IGifFileReader, GifFileReader>();
        services.AddSingleton<IGifFileWriter, GifFileWriter>();

        services.AddScoped<IGifReader, GifReader>();
        services.AddScoped<IGifWriter, GifWriter>();
        
        services.AddPostgresDbContext(config);

        return services;
    }
}