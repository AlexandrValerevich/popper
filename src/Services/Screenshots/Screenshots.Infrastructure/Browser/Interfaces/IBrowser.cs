using Screenshots.Browser.Interfaces;

namespace Screenshots.Infrastructure.Browser.Interfaces;

internal interface IBrowser : ITakeScreenshot, IDisposable
{
    DateTime StartUsageDate { get; }
    DateTime LastUsageDate { get; }

    void NavigateTo(Uri uri);
    IHtmlElement GetHtmlElementBySelector(string selector);
    void Quit();
}