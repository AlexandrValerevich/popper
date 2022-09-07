using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poppers.Infrastructure.Persistence.EF.Contexts;

namespace Poppers.Infrastructure.Persistence.EF;

public static class DependencyInjection
{
    public static IServiceCollection AddInMemoryDbContext(this IServiceCollection services)
    {
        services.AddDbContext<GifDbContext>(
            opt => opt.UseInMemoryDatabase("GifContext"));

        return services;
    }

    public static IServiceCollection AddPostgresDbContext(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<GifDbContext>(opt =>
            opt.UseNpgsql(config.GetConnectionString("Gifs")));

        return services;
    }
}