using Screenshots.Browser.Interfaces;

namespace Screenshots.Browser;

internal class BrowserExecutor : IBrowserExecutor
{
    private readonly IBrowserPool _browserPool;

    public BrowserExecutor(IBrowserPool browserPool)
    {
        _browserPool = browserPool;
    }

    public T Execute<T>(Func<IBrowser, T> callback)
    {
        IBrowser browser = _browserPool.Get();
        T result;
        try
        {
            result = callback.Invoke(browser);
        }
        finally
        {
            _browserPool.Return(browser);
        }

        return result;
    }

    public Task<T> ExecuteAsync<T>(Func<IBrowser, T> callback)
    {
        return Task.FromResult(Execute(callback));
    }

    public async Task<T> ExecuteAsync<T>(Func<IBrowser, Task<T>> callback)
    {
        IBrowser browser = _browserPool.Get();
        T result;
        try
        {
            result = await callback.Invoke(browser);
        }
        finally
        {
            _browserPool.Return(browser);
        }

        return result;
    }

}