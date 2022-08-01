using Microsoft.Extensions.DependencyInjection;

namespace Shared.GifFile;

public static class DependencyInjection
{
    public static IServiceCollection AddGifFileClient(this IServiceCollection services)
    {
        return services;
    }
}