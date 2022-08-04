using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Bulkhead;
using Polly.CircuitBreaker;
using Polly.Extensions.Http;
using Polly.Registry;
using Polly.Retry;
using Polly.Timeout;
using Shared.GifFiles.Options;

namespace Shared.GifFiles.Policies;

public static class DependencyInjection
{
    public static IServiceCollection AddPolicies(this IServiceCollection services,
        Action<HttpGifFileClientOptions> builder)
    {
        var options = new HttpGifFileClientOptions();
        builder.Invoke(options);

        var retry = CreateWaitAndRetryPolicy(options);
        var breaker = CreateCircuitBreakerPolicy(options);
        var timeout = CreateTimeOutPolicy(options);
        var bulkhead = CreateBulkHeadPolicy(options);
        var httpGiffiles = Policy.WrapAsync(retry, breaker, bulkhead, timeout);

        var pairs = new List<KeyValuePair<string, IsPolicy>>
        {
            new(PolicyKeys.RetriesAndWaits, retry),
            new(PolicyKeys.CircleBrackets, breaker),
            new(PolicyKeys.TimeOut, timeout),
            new(PolicyKeys.BulkHead, bulkhead),
            new(PolicyKeys.HttpGiffilesClient, httpGiffiles)
        };

        services.AddPolicies(pairs);

        return services;
    }

    private static void AddPolicies(this IServiceCollection services,
        List<KeyValuePair<string, IsPolicy>> policies)
    {
        using var provider = services.BuildServiceProvider();
        var register = provider.GetService<IPolicyRegistry<string>>();

        if (register == null)
        {
            register = new PolicyRegistry();
        }

        foreach (KeyValuePair<string, IsPolicy> policy in policies)
        {
            register.Add(policy.Key, policy.Value);
        }

        services.AddPolicyRegistry(register);
    }

    private static AsyncBulkheadPolicy<HttpResponseMessage> CreateBulkHeadPolicy(HttpGifFileClientOptions options)
    {
        return Policy.BulkheadAsync<HttpResponseMessage>(
            options.MaxParallel,
            options.MaxQueue
        );
    }

    private static AsyncTimeoutPolicy<HttpResponseMessage> CreateTimeOutPolicy(HttpGifFileClientOptions options)
    {
        return Policy.TimeoutAsync<HttpResponseMessage>(options.TimeOut);
    }

    private static AsyncCircuitBreakerPolicy<HttpResponseMessage> CreateCircuitBreakerPolicy(HttpGifFileClientOptions options)
    {
        return HttpPolicyExtensions.HandleTransientHttpError()
            .CircuitBreakerAsync(options.MaxConsecutiveBrake,
                TimeSpan.FromSeconds(options.WaitAfterConsecutiveBrake));
    }

    private static AsyncRetryPolicy<HttpResponseMessage> CreateWaitAndRetryPolicy(HttpGifFileClientOptions options)
    {
        var jitterer = new Random();
        return HttpPolicyExtensions.HandleTransientHttpError()
            .Or<TimeoutRejectedException>()
            .WaitAndRetryAsync(options.Retry,
                attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt * options.MinWait))
                        + TimeSpan.FromMilliseconds(jitterer.Next(0, 1000)));
    }
}