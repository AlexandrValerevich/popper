using OpenQA.Selenium.Chrome;
using Poppers.Infrastructure.Browser.Interfaces;

namespace Poppers.Infrastructure.Browser;

internal class BrowserFactory : IBrowserFactory
{
    public IBrowser Create()
    {
        var driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        
        return new Browser(driver);
    }
}