using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poppers.Application.Common.Interfaces.Authentication;

namespace Poppers.Infrastructure.Authentication;

public static class DependencyInjection
{
    public static IServiceCollection AddAuth(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IPasswordChecker, PasswordChecker>();

        services.Configure<JwtSettings>(config.GetSection(JwtSettings.SectionName));

        return services;
    }
}