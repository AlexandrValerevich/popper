using Microsoft.Extensions.DependencyInjection;
using Poppers.Application.Common.Interfaces.Persistence;

namespace Poppers.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IGifCreator, GifCreator>();
        services.AddScoped<IGifReader, GifReader>();
        services.AddScoped<IGifRemover, GifRemover>();
        return services;
    }
}