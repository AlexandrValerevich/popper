using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using Screenshots.Infrastructure.Browser.Interfaces;
using Serilog;

namespace Screenshots.Infrastructure.Browser;

internal class Browser : IBrowser
{
    private readonly IWebDriver _driver;

    public DateTime StartUsageDate { get; }

    public DateTime LastUsageDate { get; private set; }

    public Size Size => _driver.Manage().Window.Size;

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

    public IScreenshot TakeScreenshot()
    {
        LastUsageDate = DateTime.Now;
        return new Screenshot(_driver.TakeScreenshot());
    }

    public void Quit()
    {
        _driver.Quit();
    }

    public void Dispose()
    {
        Log.Information(
            "Browser Closed {LastUsageDate}", 
            LastUsageDate);
        Quit();
        GC.SuppressFinalize(this);
    }
}