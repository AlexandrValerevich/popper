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

    public IScreenshot TakeScreenshot()
    {
        return new Screenshot(
            (_element as ITakesScreenshot)?.GetScreenshot()
        );
    }
}