using Microsoft.Extensions.DependencyInjection;
using Poppers.Application.Common.Interfaces.Authentication;

namespace Poppers.Infrastructure.Authentication;

public static class DependencyInjection
{
    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IPasswordChecker, PasswordChecker>();
        return services;
    }
}