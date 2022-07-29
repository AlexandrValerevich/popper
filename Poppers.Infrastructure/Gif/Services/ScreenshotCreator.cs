using Poppers.Application.Gif.Common;
using Poppers.Application.Gif.Interfaces;
using Poppers.Browser.Interfaces;
using GifDomain = Poppers.Domain.Entities.Gif;

namespace Poppers.Infrastructure.Gif.Services;

public class ScreenshotCreator : IScreenshotCreator
{
    private readonly IBrowserExecutor _browserExecutor;

    public ScreenshotCreator(IBrowserExecutor browserExecutor)
    {
        _browserExecutor = browserExecutor;
    }

    public async Task<ScreenshotList> TakeScreenshots(GifDomain gif) 
        => await _browserExecutor.ExecuteAsync(async (browser) =>
    {
        browser.NavigateTo(gif.Uri);

        IHtmlElement htmlElement = browser.GetHtmlElementBySelector(gif.Selector);
        var screenshots = new ScreenshotList();
        var timerCallback = new TimerCallback((obj) =>
        {
            var screenshot = new Screenshot()
            {
                Value = htmlElement.TakeScreenshot()
            };
            screenshots.Value.Add(screenshot);
        });

        using (var timer = new Timer(timerCallback, 0, 0, gif.Delay))
        {
            await Task.Delay(TimeSpan.FromSeconds(gif.Duration));
        }

        return screenshots;
    });
}