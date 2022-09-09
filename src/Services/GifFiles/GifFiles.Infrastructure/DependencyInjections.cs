using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poppers.Infrastructure.Persistence;
using Shared.Common;

namespace GifFiles.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddPersistance(config);
        services.AddValidationBehavior();
        
        return services;
    }
}