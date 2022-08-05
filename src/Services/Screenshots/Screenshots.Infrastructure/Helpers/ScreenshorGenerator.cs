using System.Diagnostics;
using Screenshots.Application.Common;
using Screenshots.Application.Interfaces;
using Screenshots.Infrastructure.Browser.Interfaces;

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
            IEnumerable<string> screenshotCreationResult = Array.Empty<string>();

            await _screenshotGenerator.ExecuteAsync( (browser) =>
            {
                browser.NavigateTo(uri);
                IHtmlElement htmlElement = browser.GetHtmlElementBySelector(selector);

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var screenshots = new List<IScreenshot>();
                while (stopwatch.Elapsed < TimeSpan.FromSeconds(duration))
                {
                    screenshots.Add(htmlElement.TakeScreenshot());
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
    }

}