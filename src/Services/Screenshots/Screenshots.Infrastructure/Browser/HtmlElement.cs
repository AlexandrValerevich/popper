using System.Drawing;
using OpenQA.Selenium;
using Screenshots.Infrastructure.Browser.Interfaces;

namespace Screenshots.Infrastructure.Browser;

internal class HtmlElement : IHtmlElement
{

    private readonly IWebElement _element;

    public HtmlElement(IWebElement element)
    {
        _element = element;
    }

    public Size Size => _element.Size;

    public Point Position => _element.Location;

    public IScreenshot TakeScreenshot()
    {
        return new Screenshot(
            (_element as ITakesScreenshot)?.GetScreenshot()
        );
    }
}