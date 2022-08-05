using Screenshots.Browser.Interfaces;

namespace Screenshots.Browser;

internal class BrowserExecutor : IBrowserExecutor
{
    private readonly IBrowserPool _browserPool;

    public BrowserExecutor(IBrowserPool browserPool)
    {
        _browserPool = browserPool;
    }

    public void Execute(Action<IBrowser> callback)
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
    }

    public async Task ExecuteAsync(Func<IBrowser, Task> callback, CancellationToken token)
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
    }
}