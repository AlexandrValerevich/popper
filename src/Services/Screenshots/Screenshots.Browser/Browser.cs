using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Screenshots.Browser.Interfaces;

namespace Screenshots.Browser;

internal class Browser : IBrowser
{
    private readonly IWebDriver _driver;

    public Browser(IWebDriver driver)
    {
        _driver = driver;
    }

    public IHtmlElement GetHtmlElementBySelector(string selector)
    {
        WebDriverWait wait = new(_driver, TimeSpan.FromSeconds(10));
        var element = wait.Until(e => e.FindElement(By.CssSelector(selector)));

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

    public void Quit()
    {
        _driver.Quit();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}