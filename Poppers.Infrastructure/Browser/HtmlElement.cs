using OpenQA.Selenium;
using Poppers.Infrastructure.Browser.Interfaces;

namespace Poppers.Infrastructure.Browser;

public class HtmlElement : IHtmlElement
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