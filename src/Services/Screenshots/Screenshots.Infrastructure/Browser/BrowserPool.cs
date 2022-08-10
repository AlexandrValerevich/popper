using System.Collections.Concurrent;
using Screenshots.Infrastructure.Browser.Interfaces;

namespace Screenshots.Infrastructure.Browser;

internal class BrowserPool : IBrowserPool, IDisposable
{
    private readonly ConcurrentBag<IBrowser> _bag = new();
    private readonly IBrowserFactory _browserFactory;

    public BrowserPool(IBrowserFactory browserFactory)
    {
        _browserFactory = browserFactory;
    }

    public IBrowser Get()
    {
        return _bag.TryTake(out var browser) ? browser : _browserFactory.Create();
    }

    public void Return(IBrowser browser)
    {
        _bag.Add(browser);
    }

    public void Dispose()
    {
        foreach (IBrowser browser in _bag)
        {
            browser.Dispose();
        }
        GC.SuppressFinalize(this);
    }
}