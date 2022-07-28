using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Poppers.Infrastructure.Browser.Interfaces;

namespace Poppers.Infrastructure.Browser;

public class Browser : IBrowser
{
    private readonly IWebDriver _driver;

    public Browser(IWebDriver driver)
    {
        _driver = driver;
    }

    public IHtmlElement GetHtmlElementBySelector(string selector)
    {
        IWebElement element = _driver.FindElement(By.CssSelector(selector));
        return new HtmlElement(element);
    }

    public void NavigateTo(Uri uri)
    {
        _driver.Navigate().GoToUrl(uri);
    }

    public byte[] TakeScreenshot()
    {
        return _driver.TakeScreenshot().AsByteArray;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}