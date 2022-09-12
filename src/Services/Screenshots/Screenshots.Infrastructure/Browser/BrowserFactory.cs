using Microsoft.Extensions.Options;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using Screenshots.Infrastructure.Browser.Interfaces;
using Serilog;

namespace Screenshots.Infrastructure.Browser;

internal sealed class BrowserFactory : IBrowserFactory
{
    private readonly BrowserSettings _settings;
    public BrowserFactory(IOptions<BrowserSettings> settings)
    {
        _settings = settings.Value;
    }

    public IBrowser Create()
    {
        // var driver = new FirefoxDriver(new FirefoxOptions
        // {
        //     LogLevel = FirefoxDriverLogLevel.Error
        // });
        // var driver = new ChromeDriver();

        // var driver = new EdgeDriver(_service);

        var driver = new RemoteWebDriver(new Uri(_settings.BrowserUrl), new ChromeOptions());
        driver.Manage().Window.FullScreen();

        return new Browser(driver);
    }
}