namespace Screenshots.Browser.Interfaces;

internal interface IBrowser : ITakeScreenshot, IDisposable
{
    void NavigateTo(Uri uri);
    IHtmlElement GetHtmlElementBySelector(string selector);
    void Quit();
}