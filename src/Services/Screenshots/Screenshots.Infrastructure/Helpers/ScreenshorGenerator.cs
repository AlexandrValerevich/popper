using System.Diagnostics;
using Screenshots.Application.Common;
using Screenshots.Application.Interfaces;
using Screenshots.Browser.Interfaces;

namespace Screenshots.Infrastructure.Helpers
{
    internal class ScreenshotGenerator : IScreenshotGenerator
    {
        private readonly IBrowserExecutor _screenshotGenerator;

        public ScreenshotGenerator(IBrowserExecutor browserExecutor)
        {
            _screenshotGenerator = browserExecutor;
        }

        public Task<ScreenshotsList> GenerateAsync(Uri uri, string selector, int duration, CancellationToken token)
            => _screenshotGenerator.Execute((browser) =>
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

                return Task.FromResult(new ScreenshotsList()
                {
                    Screenshots = screenshots
                });
            });
    }

}