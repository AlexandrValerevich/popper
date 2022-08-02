using Screenshots.Application.DTO;

namespace Screenshots.Application.Interfaces;

public interface IScreenshotService
{
    Task<ScreenshotsListDTO> TakeScreenshots(Uri uri, string selector, int duration);
}