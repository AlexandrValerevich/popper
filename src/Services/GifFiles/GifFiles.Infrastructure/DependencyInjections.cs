using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poppers.Infrastructure.Persistence;
using Shared.Common;

namespace GifFiles.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPersistance();
        services.AddValidationBehavior();
        
        return services;
    }
}