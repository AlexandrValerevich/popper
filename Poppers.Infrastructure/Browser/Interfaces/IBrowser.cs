namespace Poppers.Infrastructure.Browser.Interfaces;

public interface IBrowser : ITakeScreenshot, IDisposable
{
    void NavigateTo(Uri uri);
    IHtmlElement GetHtmlElementBySelector(string selector);
}