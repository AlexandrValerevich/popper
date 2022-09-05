namespace Poppers.Api.Middleware;

public static class DependencyInjection
{
    public static IServiceCollection AddMiddleware(this IServiceCollection services)
    {
        services.AddScoped<ErrorHandlerMiddleware>();
        return services;
    }
}