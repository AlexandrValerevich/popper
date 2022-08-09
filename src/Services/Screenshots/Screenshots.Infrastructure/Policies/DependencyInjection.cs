using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using Polly;
using Polly.Bulkhead;
using Polly.Registry;
using Polly.Retry;
using Polly.Timeout;
using Polly.Wrap;
using Screenshots.Infrastructure.Options;
using Serilog;

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
        var bulkhead = CreateBulkHeadPolicy(options);
        var timeout = CreateTimeOutPolicy(options);
        AsyncPolicyWrap browserExecution = Policy.WrapAsync(retry, bulkhead, timeout);

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

    private static AsyncRetryPolicy CreateWaitAndRetryPolicy(BrowserPoolOptions options)
    {
        var jitterer = new Random();
        return Policy.Handle<StaleElementReferenceException>()
            .Or<TimeoutRejectedException>()
            .WaitAndRetryAsync(options.Retry,
                attempt => TimeSpan.FromSeconds(Math.Pow(options.Wait, attempt))
                        + TimeSpan.FromSeconds(jitterer.Next(0, 5)),
                (ex, ts, attempt, _) => Log.Warning("Exception {Exception} was thrown after {Time}, in attempt {Attempt}", ex.Message, ts, attempt));
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

}