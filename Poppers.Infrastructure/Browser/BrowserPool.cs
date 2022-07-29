using System.Collections.Concurrent;
using Microsoft.Extensions.Options;
using Poppers.Infrastructure.Browser.Interfaces;
using Poppers.Infrastructure.Browser.Options;

namespace Poppers.Infrastructure.Browser;

internal class BrowserPool : IBrowserPool
{
    private readonly ConcurrentBag<IBrowser> _bag = new();
    private readonly IBrowserFactory _browserFactory;
    private readonly BrowserPoolOption _options;

    public BrowserPool(IBrowserFactory browserFactory,
        IOptions<BrowserPoolOption> option)
    {
        _browserFactory = browserFactory;
        _options = option.Value;
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