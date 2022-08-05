using Polly;
using Polly.Registry;
using Screenshots.Browser.Interfaces;
using Shared.GifFiles.Policies;

namespace Screenshots.Browser;

internal class BrowserExecutor : IBrowserExecutor
{
    private readonly IBrowserPool _browserPool;

    private readonly IReadOnlyPolicyRegistry<string> _registry;

    public BrowserExecutor(IBrowserPool browserPool,
        IReadOnlyPolicyRegistry<string> registry)
    {
        _browserPool = browserPool;
        _registry = registry;
    }

    public void Execute(Action<IBrowser> callback)
    {
        IBrowser browser = _browserPool.Get();
        var policy = _registry.Get<IAsyncPolicy>(PolicyKeys.BrowserExecution);
        try
        {
            policy.ExecuteAsync(() =>
            {
                callback.Invoke(browser);
                return Task.CompletedTask;
            });
        }
        finally
        {
            _browserPool.Return(browser);
        }
    }

    public async Task ExecuteAsync(Func<IBrowser, Task> callback, CancellationToken token)
    {
        IBrowser browser = _browserPool.Get();
        var policy = _registry.Get<IAsyncPolicy>(PolicyKeys.BrowserExecution);
        try
        {
            await policy.ExecuteAsync(async () => await callback.Invoke(browser));
        }
        finally
        {
            _browserPool.Return(browser);
        }
    }
}