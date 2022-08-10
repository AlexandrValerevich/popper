using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using Screenshots.Application.Common;
using Screenshots.Application.Interfaces;
using Screenshots.Infrastructure.Browser.Interfaces;
using Screenshots.Infrastructure.Extensions;

#pragma warning disable CA1416

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
                using var _ = new ExecutionTimeChecker(nameof(GenerateAsync));
                browser.NavigateTo(uri);
                List<IScreenshot> screenshots = CreateScreenshots(duration, browser);

                IHtmlElement element = browser.GetHtmlElementBySelector(selector);
                screenshotCreationResult = screenshots.Select(
                    s => CropElement(s, element.Position, element.Size).ToBase64String());

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

        private static byte[] CropElement(IScreenshot screenshot, Point position, Size size)
        {
            using var img = Image.FromStream(new MemoryStream(screenshot.AsBytes())) as Bitmap;
            using var elementImg = img.Clone(new Rectangle(position, size), img.PixelFormat);
            return ConvertToBytes(elementImg);
        }

        private static byte[] ConvertToBytes(Bitmap img)
        {
            using var stream = new MemoryStream();
            img.Save(stream, ImageFormat.Png);
            return stream.ToArray();
        }
    }

}