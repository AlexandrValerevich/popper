using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poppers.Infrastructure.Persistence.EF.Contexts;

namespace Poppers.Infrastructure.Persistence.EF;

public static class DependencyInjection
{
    public static IServiceCollection AddInMemoryDbContext(this IServiceCollection services)
    {
        services.AddDbContext<ReadDbContext>(
            opt => opt.UseInMemoryDatabase("Popper"));
        return services;
    }

    public static IServiceCollection AddPostgresDbContext(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<ReadDbContext>(opt => 
            opt.UseNpgsql(config.GetConnectionString("Poppers")));
        return services;
    }
}