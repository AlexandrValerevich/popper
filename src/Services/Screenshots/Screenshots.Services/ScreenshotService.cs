using System.Diagnostics;
using Screenshots.Browser.Interfaces;
using Screenshots.Services.DTO;
using Screenshots.Services.Interfaces;

namespace Screenshots.Services;

internal class ScreenshotService : IScreenshotService
{
    private readonly IBrowserExecutor _browserExecutor;

    public ScreenshotService(IBrowserExecutor browserExecutor)
    {
        _browserExecutor = browserExecutor;
    }

    public Task<ScreenshotsListDTO> TakeScreenshots(Uri uri, string selector, int duration)
        => _browserExecutor.Execute((browser) =>
        {
            browser.NavigateTo(uri);

            IHtmlElement htmlElement = browser.GetHtmlElementBySelector(selector);
            var screenshots = new List<byte[]>();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed < TimeSpan.FromSeconds(duration))
            {
                screenshots.Add(htmlElement.TakeScreenshot());
            }
            stopwatch.Stop();

            return Task.FromResult(new ScreenshotsListDTO()
            {
                Screenshots = screenshots
            });
        });
}