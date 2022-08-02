using OpenQA.Selenium;
using Screenshots.Browser.Interfaces;

namespace Screenshots.Browser;

internal class HtmlElement : IHtmlElement
{

    private readonly IWebElement _element;

    public HtmlElement(IWebElement element)
    {
        _element = element;
    }

    public byte[] TakeScreenshot()
    {
        return (_element as ITakesScreenshot)?.GetScreenshot().AsByteArray;
    }
}