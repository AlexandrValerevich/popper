using GifFiles.Application.Interfaces;
using GifFiles.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Shared.Common;

namespace GifFiles.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IGifFileReader, GifFileReader>();
        services.AddSingleton<IGifFileWriter, GifFileWriter>();

        services.AddLogErrorBehavior();
        services.AddValidationBehavior();

        return services;
    }
}