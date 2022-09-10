using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Poppers.Infrastructure.Bechaviors;

public static class DependencyInjection
{
    public static IServiceCollection AddTransactionBechavior(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBechavior<,>));
        return services;
    }
}