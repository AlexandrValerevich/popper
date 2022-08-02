using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shared.Behaviors;

namespace Shared;

public static class DependencyInjection
{
    public static IServiceCollection AddValidationBehavior(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetCallingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}