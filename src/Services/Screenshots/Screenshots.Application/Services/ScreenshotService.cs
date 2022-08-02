using Screenshots.Application.DTO;
using Screenshots.Application.Interfaces;

namespace Screenshots.Application.Services;

internal class ScreenshotService : IScreenshotService
{
    private readonly IScreenshotGenerator _screenshotGenerator;

    public ScreenshotService(IScreenshotGenerator browserExecutor)
    {
        _screenshotGenerator = browserExecutor;
    }

    public async Task<ScreenshotsListDTO> TakeScreenshots(Uri uri, string selector, int duration)
        => await _screenshotGenerator.Generate(uri, selector, duration);
}