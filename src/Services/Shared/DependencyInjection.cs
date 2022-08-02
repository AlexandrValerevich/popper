using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shared.Common.Behaviors;

namespace Shared;

public static class DependencyInjection
{
    public static IServiceCollection AddValidationBehavior(this IServiceCollection services,
        Assembly assembly)
    {
        services.AddValidatorsFromAssembly(assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}