using Polly;
using Polly.Extensions.Http;
using System.Collections.Immutable;
using Microsoft.Extensions.DependencyInjection;
using Shared.GifFiles.Clients;
using Shared.GifFiles.Options;

namespace Shared.GifFiles;

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