using Poppers.Browser.Interfaces;

namespace Poppers.Browser;

internal class BrowserExecutor : IBrowserExecutor
{
    private readonly IBrowserPool _browserPool;

    public BrowserExecutor(IBrowserPool browserPool, 
        IExecutorQueriesQueue queue)
    {
        _browserPool = browserPool;
    }

    public T Execute<T>(Func<IBrowser, T> callback)
    {
        IBrowser browser = _browserPool.Get();
        T result = callback.Invoke(browser);
        _browserPool.Return(browser);

        return result;
    }

    public async Task<T> ExecuteAsync<T>(Func<IBrowser, Task<T>> callback)
    {
        IBrowser browser = _browserPool.Get();
        T result = await callback.Invoke(browser);
        _browserPool.Return(browser);

        return result;
    }

    public Task<T> ExecuteAsync<T>(Func<IBrowser, T> callback)
    {
        return Task.FromResult(Execute(callback));
    }
}