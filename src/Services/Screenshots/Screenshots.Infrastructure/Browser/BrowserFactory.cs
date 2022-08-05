using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using Screenshots.Infrastructure.Browser.Interfaces;

namespace Screenshots.Infrastructure.Browser;

internal class BrowserFactory : IBrowserFactory
{
    private readonly EdgeDriverService _service;

    public BrowserFactory()
    {
        _service = EdgeDriverService.CreateDefaultService();
    }

    public IBrowser Create()
    {
        // var driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/"), new FirefoxOptions());
        // var driver = new FirefoxDriver(new FirefoxOptions
        // {
        //     LogLevel = FirefoxDriverLogLevel.Error
        // });
        // var driver = new ChromeDriver();

        var driver = new EdgeDriver(_service);
        driver.Manage().Window.Maximize();

        return new Browser(driver);
    }
}