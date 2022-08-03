using Microsoft.Extensions.DependencyInjection;
using Shared.Screenshots.Client;
using Shared.Screenshots.Options;

namespace Shared.Screenshots;

public static class DependencyInjection
{
    public static IServiceCollection AddScreenshotClient(this IServiceCollection services,
        Action<HttpScreenshotClientOptions> options)
    {
        var clintOptions = new HttpScreenshotClientOptions();
        options.Invoke(clintOptions);

        services.AddHttpClient<IHttpScreenshotClient, HttpScreenshotClient>(client =>
        {
            client.BaseAddress = new Uri(clintOptions.BaseUrl);
        });
         
        return services;
    }
}