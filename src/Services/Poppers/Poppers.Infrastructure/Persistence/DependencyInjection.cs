using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poppers.Application.Common.Interfaces;
using Poppers.Application.Common.Interfaces.Persistence;
using Poppers.Domain.Interfaces;
using Poppers.Infrastructure.Persistence.EF;

namespace Poppers.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddScoped<IGifCreator, GifCreator>();
        services.AddScoped<IGifReader, GifReader>();
        services.AddScoped<IGifRemover, GifRemover>();

        services.AddScoped<IUserReader, UserReader>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddPostgresDbContext(config);
        return services;
    }
}