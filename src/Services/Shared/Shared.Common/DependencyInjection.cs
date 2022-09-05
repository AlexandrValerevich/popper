using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shared.Common.Behaviors;

namespace Shared.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddValidationBehavior(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }

    public static IServiceCollection AddLogErrorBehavior(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LogErrorBehavior<,>));
        return services;
    }
}