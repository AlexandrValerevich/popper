using OpenQA.Selenium;
using Poppers.Browser.Interfaces;

namespace Poppers.Browser;

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