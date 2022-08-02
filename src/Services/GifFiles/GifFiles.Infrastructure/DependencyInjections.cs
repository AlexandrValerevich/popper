using GifFiles.Application.Interfaces;
using GifFiles.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Shared;

namespace GifFiles.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IGifReader, GifReader>();
        services.AddSingleton<IGifWriter, GifWriter>();
        services.AddSingleton<IGifRemover, GifRemover>();

        services.AddValidationBehavior();

        return services;
    }
}