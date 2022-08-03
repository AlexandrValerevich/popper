using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Screenshots.Browser.Interfaces;
using Serilog;

namespace Screenshots.Browser;

internal class Browser : IBrowser
{
    private readonly IWebDriver _driver;

    public DateTime StartUsageDate { get; }
    public DateTime LastUsageDate { get; private set; }

    public Browser(IWebDriver driver)
    {
        StartUsageDate = DateTime.Now;
        LastUsageDate = DateTime.Now;
        Log.Information("New Browser Opened {StartUsageDate}", StartUsageDate);
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
        LastUsageDate = DateTime.Now;
        _driver.Navigate().GoToUrl(uri);
    }

    public byte[] TakeScreenshot()
    {
        LastUsageDate = DateTime.Now;
        return _driver.TakeScreenshot().AsByteArray;
    }

    public void Quit()
    {
        _driver.Quit();
    }

    public void Dispose()
    {
        Log.Information("Browser Closed {LastUsageDate}", LastUsageDate);
        GC.SuppressFinalize(this);
    }
}