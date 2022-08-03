using Microsoft.Extensions.DependencyInjection;
using Shared.Screenshots.Client;
using Shared.Screenshots.Options;
using Shared.Screenshots.Policies;

namespace Shared.Screenshots;

public static class DependencyInjection
{
    public static IServiceCollection AddScreenshotClient(this IServiceCollection services,
        Action<HttpScreenshotClientOptions> builder)
    {
        var clintOptions = new HttpScreenshotClientOptions();
        builder.Invoke(clintOptions);

        services.AddPolicies(builder);
        services.AddHttpClient<IHttpScreenshotClient, HttpScreenshotClient>(client =>
        {
            client.BaseAddress = new Uri(clintOptions.BaseUrl);
        })
        .AddPolicyHandlerFromRegistry(PolicyKeys.HttpScreenshotClient);

        return services;
    }
}