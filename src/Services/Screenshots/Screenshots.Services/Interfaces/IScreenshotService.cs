using Screenshots.Services.DTO;

namespace Screenshots.Services.Interfaces;

public interface IScreenshotService
{
    Task<ScreenshotsListDTO> TakeScreenshots(Uri uri, string selector, int duration);
}