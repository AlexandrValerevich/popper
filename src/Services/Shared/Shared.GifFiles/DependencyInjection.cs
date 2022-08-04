using Microsoft.Extensions.DependencyInjection;
using Shared.GifFiles.Clients;
using Shared.GifFiles.Options;
using Shared.GifFiles.Policies;

namespace Shared.GifFiles;

public static class DependencyInjection
{
    public static IServiceCollection AddGifFileClient(this IServiceCollection services,
        Action<HttpGifFileClientOptions> builder)
    {
        var clintOptions = new HttpGifFileClientOptions();
        builder.Invoke(clintOptions);

        services.AddPolicies(builder);
        services.AddHttpClient<IHttpGifFileClient, HttpGifFileClient>(client =>
        {
            client.BaseAddress = new Uri(clintOptions.BaseUrl);
        })
        .AddPolicyHandlerFromRegistry(PolicyKeys.HttpGiffilesClient);

        return services;
    }

}