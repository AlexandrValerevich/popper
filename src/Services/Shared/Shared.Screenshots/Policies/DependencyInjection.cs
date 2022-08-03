using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Bulkhead;
using Polly.CircuitBreaker;
using Polly.Extensions.Http;
using Polly.Registry;
using Polly.Retry;
using Polly.Timeout;
using Shared.Screenshots.Options;

namespace Shared.Screenshots.Policies;

public static class DependencyInjection
{
    public static IServiceCollection AddPolicies(this IServiceCollection services,
        Action<HttpScreenshotClientOptions> builder)
    {
        var options = new HttpScreenshotClientOptions();
        builder.Invoke(options);

        var retry = CreateWaitAndRetryPolicy(options);
        var breaker = CreateCircuitBreakerPolicy(options);
        var timeout = CreateTimeOutPolicy(options);
        var bulkhead = CreateBulkHeadPolicy(options);
        var httpScreenshot = Policy.WrapAsync(retry, breaker, bulkhead, timeout);

        var register = new PolicyRegistry
        {
            { PolicyKeys.RetriesAndWaits, retry },
            { PolicyKeys.CircleBrackets, breaker },
            { PolicyKeys.TimeOut, timeout },
            { PolicyKeys.BulkHead, bulkhead },
            { PolicyKeys.HttpScreenshotClient, httpScreenshot }
        };

        services.AddPolicyRegistry(register);
        return services;
    }

    private static AsyncBulkheadPolicy<HttpResponseMessage> CreateBulkHeadPolicy(HttpScreenshotClientOptions options)
    {
        return Policy.BulkheadAsync<HttpResponseMessage>(
            options.MaxParallel,
            options.MaxQueue
        );
    }

    private static AsyncTimeoutPolicy<HttpResponseMessage> CreateTimeOutPolicy(HttpScreenshotClientOptions options)
    {
        return Policy.TimeoutAsync<HttpResponseMessage>(options.TimeOut);
    }

    private static AsyncCircuitBreakerPolicy<HttpResponseMessage> CreateCircuitBreakerPolicy(HttpScreenshotClientOptions options)
    {
        return HttpPolicyExtensions.HandleTransientHttpError()
            .CircuitBreakerAsync(options.MaxConsecutiveBrake,
                TimeSpan.FromSeconds(options.WaitAfterConsecutiveBrake));
    }

    private static AsyncRetryPolicy<HttpResponseMessage> CreateWaitAndRetryPolicy(HttpScreenshotClientOptions options)
    {
        var jitterer = new Random();
        return HttpPolicyExtensions.HandleTransientHttpError()
            .Or<TimeoutRejectedException>()
            .WaitAndRetryAsync(options.Retry,
                attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt * options.MinWait))
                        + TimeSpan.FromMilliseconds(jitterer.Next(0, 1000)));
    }
}