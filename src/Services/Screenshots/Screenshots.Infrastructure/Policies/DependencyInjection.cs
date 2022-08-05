using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using Polly;
using Polly.Bulkhead;
using Polly.Registry;
using Polly.Retry;
using Polly.Timeout;
using Screenshots.Infrastructure.Options;

namespace Shared.GifFiles.Policies;

#nullable enable

public static class DependencyInjection
{
    public static IServiceCollection AddPolicies(this IServiceCollection services,
        Action<BrowserPoolOptions>? builder = null)
    {
        var options = new BrowserPoolOptions();
        builder?.Invoke(options);

        var retry = CreateWaitAndRetryPolicy(options);
        var timeout = CreateTimeOutPolicy(options);
        var bulkhead = CreateBulkHeadPolicy(options);
        var browserExecution = Policy.WrapAsync(retry, bulkhead, timeout);

        var pairs = new List<KeyValuePair<string, IsPolicy>>
        {
            new(PolicyKeys.RetriesAndWaits, retry),
            new(PolicyKeys.TimeOut, timeout),
            new(PolicyKeys.BulkHead, bulkhead),
            new(PolicyKeys.BrowserExecution, browserExecution)
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

    private static AsyncBulkheadPolicy CreateBulkHeadPolicy(BrowserPoolOptions options)
    {
        return Policy.BulkheadAsync(
            options.MaxParallel,
            options.MaxQueue
        );
    }

    private static AsyncTimeoutPolicy CreateTimeOutPolicy(BrowserPoolOptions options)
    {
        return Policy.TimeoutAsync(options.TimeOut);
    }

    private static AsyncRetryPolicy CreateWaitAndRetryPolicy(BrowserPoolOptions options)
    {
        var jitterer = new Random();
        return Policy.Handle<NoSuchElementException>()
            .WaitAndRetryAsync(options.Retry,
                attempt => TimeSpan.FromSeconds(attempt * options.Wait)
                        + TimeSpan.FromMilliseconds(jitterer.Next(0, 1000)));
    }
}