using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace Poppers.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}