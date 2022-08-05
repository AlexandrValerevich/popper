using Screenshots.Infrastructure.Browser.Interfaces;

namespace Screenshots.Browser.Interfaces;

internal interface ITakeScreenshot
{
    IScreenshot TakeScreenshot();
}