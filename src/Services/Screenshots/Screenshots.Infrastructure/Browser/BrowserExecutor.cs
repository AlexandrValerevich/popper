using Polly;
using Polly.Registry;
using Screenshots.Infrastructure.Browser.Interfaces;
using Shared.GifFiles.Policies;

namespace Screenshots.Infrastructure.Browser;

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
        var policy = _registry.Get<IAsyncPolicy>(PolicyKeys.BrowserExecution);
        policy.ExecuteAsync(() =>
        {
            IBrowser browser = _browserPool.Get();
            try
            {
                callback.Invoke(browser);
            }
            finally
            {
                _browserPool.Return(browser);
            }
            return Task.CompletedTask;
        });
    }

    public async Task ExecuteAsync(Func<IBrowser, Task> callback, CancellationToken token)
    {
        var policy = _registry.Get<IAsyncPolicy>(PolicyKeys.BrowserExecution);
        await policy.ExecuteAsync(async () =>
        {
            IBrowser browser = _browserPool.Get();
            try
            {
                await callback.Invoke(browser);
            }
            finally
            {
                _browserPool.Return(browser);
            }
        });
    }
}