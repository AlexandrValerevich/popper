using Screenshots.Application.DTO;

namespace Screenshots.Application.Interfaces;

public interface IScreenshotGenerator
{
    Task<ScreenshotsListDTO> Generate(Uri uri, string selector, int duration, CancellationToken token);
}