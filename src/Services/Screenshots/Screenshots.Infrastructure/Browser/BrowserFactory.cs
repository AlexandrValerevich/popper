using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using Screenshots.Infrastructure.Browser.Interfaces;

namespace Screenshots.Infrastructure.Browser;

internal class BrowserFactory : IBrowserFactory
{
    // private readonly ChromeDriverService _service;

    public BrowserFactory()
    {
        // _service = ChromeDriverService.CreateDefaultService();
    }

    public IBrowser Create()
    {
        // var driver = new FirefoxDriver(new FirefoxOptions
        // {
        //     LogLevel = FirefoxDriverLogLevel.Error
        // });
        // var driver = new ChromeDriver();

        // var driver = new EdgeDriver(_service);
        
        var driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/"), new ChromeOptions());
        driver.Manage().Window.FullScreen();

        return new Browser(driver);
    }
}