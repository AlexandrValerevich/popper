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

        public async Task<ScreenshotsList> GenerateAsync(Uri uri, string selector, int duration, CancellationToken token)
        {
            var screenshots = new List<byte[]>();
            await _screenshotGenerator.ExecuteAsync((browser) =>
            {
                browser.NavigateTo(uri);
                IHtmlElement htmlElement = browser.GetHtmlElementBySelector(selector);

                var stopwatch = new Stopwatch();
                stopwatch.Start();
                while (stopwatch.Elapsed < TimeSpan.FromSeconds(duration))
                {
                    screenshots.Add(htmlElement.TakeScreenshot());
                }
                stopwatch.Stop();

                return Task.CompletedTask;
            },
             token);

            return new ScreenshotsList()
            {
                Screenshots = screenshots
            };
        }
    }

}