using System.Collections.Concurrent;
using Poppers.Infrastructure.Browser.Interfaces;

namespace Poppers.Infrastructure.Browser;

internal class BrowserPool : IBrowserPool
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
}