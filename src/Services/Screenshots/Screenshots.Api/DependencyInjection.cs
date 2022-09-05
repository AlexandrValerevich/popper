using Screenshots.Api.Middleware;

namespace Screenshots.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddMiddleware();

        return services;
    }
}
