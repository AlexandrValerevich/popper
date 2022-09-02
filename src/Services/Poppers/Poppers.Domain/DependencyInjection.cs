using Microsoft.Extensions.DependencyInjection;
using Poppers.Domain.Factory;

namespace Poppers.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddSingleton<IGifFactory, GifFactory>();
        services.AddSingleton<IUserFactory, UserFactory>();
        return services;
    }
}