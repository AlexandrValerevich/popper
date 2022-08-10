using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using Screenshots.Application.Common;
using Screenshots.Application.Interfaces;
using Screenshots.Infrastructure.Browser.Interfaces;

namespace Screenshots.Infrastructure.Helpers
{
    internal class ScreenshotGenerator : IScreenshotGenerator
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
                browser.NavigateTo(uri);
                IHtmlElement element = browser.GetHtmlElementBySelector(selector);
                Size size = element.Size;
                Point position = element.Position;

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var screenshots = new List<IScreenshot>();
                while (stopwatch.Elapsed < TimeSpan.FromSeconds(duration))
                {

                    // screenshots.Add(element.TakeScreenshot());
                }

                stopwatch.Stop();
                screenshotCreationResult = screenshots.Select(s => s.AsBase64String());
                return Task.CompletedTask;
            },
            token);

            return new ScreenshotsList()
            {
                Screenshots = screenshotCreationResult
            };
        }

        private Bitmap MakeElementScreenshot(IBrowser browser, Point position, Size size)
        {
            IScreenshot screenshot = browser.TakeScreenshot();

            using var screenBmp = new Bitmap(new MemoryStream(screenshot.AsBytes()));
            return screenBmp.Clone(new Rectangle(position, size), PixelFormat.DontCare);
        }
    }

}