using Microsoft.Extensions.DependencyInjection;
using Shared.GifFile.Clients;
using Shared.GifFile.Options;

namespace Shared.GifFile;

public static class DependencyInjection
{
    public static IServiceCollection AddGifFileClient(this IServiceCollection services,
        Action<HttpGifFileClientOptions> options)
    {
        var clintOptions = new HttpGifFileClientOptions();
        options.Invoke(clintOptions);

        services.AddHttpClient<IHttpGifFileClient, HttpGifFileClient>(client =>
        {
            client.BaseAddress = new Uri(clintOptions.BaseUrl);
        });

        return services;
    }

}