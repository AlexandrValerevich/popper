using Microsoft.Extensions.DependencyInjection;

namespace Shared.GifFiles.Policy;

public static class DependencyInjection
{
    public static IServiceCollection AddPolicies(this IServiceCollection services)
    {
        return services;
    }
}