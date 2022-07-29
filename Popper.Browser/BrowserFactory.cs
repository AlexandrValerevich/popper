using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Poppers.Browser.Interfaces;

namespace Poppers.Browser;

internal class BrowserFactory : IBrowserFactory
{
    public IBrowser Create()
    {
        // var driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/"), new ChromeOptions());
        var driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        
        return new Browser(driver);
    }
}