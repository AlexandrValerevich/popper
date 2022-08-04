using Screenshots.Application.Common;

namespace Screenshots.Application.Interfaces;

public interface IScreenshotGenerator
{
    Task<ScreenshotsList> GenerateAsync(Uri uri, string selector, int duration, CancellationToken token);
}