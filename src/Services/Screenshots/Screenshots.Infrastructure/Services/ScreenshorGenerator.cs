using System.Diagnostics;
using System.Drawing;
using ImageMagick;
using Screenshots.Application.Common;
using Screenshots.Application.Interfaces;
using Screenshots.Infrastructure.Browser.Interfaces;
using Screenshots.Infrastructure.Helpers;

// #pragma warning disable CA1416

namespace Screenshots.Infrastructure.Services;

internal sealed class ScreenshotGenerator : IScreenshotGenerator
{
    private readonly IBrowserExecutor _browserExecutor;

    public ScreenshotGenerator(IBrowserExecutor browserExecutor)
    {
        _browserExecutor = browserExecutor;
    }

    public async Task<ScreenshotsList> GenerateAsync(Uri uri, string selector, int duration, CancellationToken token)
    {
        IEnumerable<string> screenshotCreationResult = Array.Empty<string>();

        await _browserExecutor.ExecuteAsync((browser) =>
        {
            using var _ = new ExecutionTimeChecker(nameof(GenerateAsync));

            browser.NavigateTo(uri);
            List<IScreenshot> screenshots = CreateScreenshots(duration, browser);

            IHtmlElement element = browser.GetHtmlElementBySelector(selector);
            screenshotCreationResult = screenshots.Select(s => CropElement(s, element.Position, element.Size));

            return Task.CompletedTask;
        },
        token);

        return new ScreenshotsList()
        {
            Screenshots = screenshotCreationResult
        };
    }

    private static List<IScreenshot> CreateScreenshots(int duration, IBrowser browser)
    {
        var stopwatch = new Stopwatch();
        var screenshots = new List<IScreenshot>();
        stopwatch.Start();
        while (stopwatch.Elapsed < TimeSpan.FromSeconds(duration))
        {
            screenshots.Add(browser.TakeScreenshot());
        }
        stopwatch.Stop();
        return screenshots;
    }

    private static string CropElement(IScreenshot screenshot, Point position, Size size)
    {
        var magickImage = new MagickImage(screenshot.AsBytes());
        var magickGeomitry = new MagickGeometry(position.X, position.Y, size.Width, size.Height)
        {
            IgnoreAspectRatio = true
        };

        magickImage.Crop(magickGeomitry);
        magickImage.Resize(magickGeomitry);

        magickImage.Format = MagickFormat.Jpeg;

        return magickImage.ToBase64();
    }
}