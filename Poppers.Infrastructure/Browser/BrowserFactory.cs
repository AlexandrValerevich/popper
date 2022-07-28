using OpenQA.Selenium.Chrome;
using Poppers.Infrastructure.Browser.Interfaces;

namespace Poppers.Infrastructure.Browser;

internal class BrowserFactory : IBrowserFactory
{
    public IBrowser Create()
    {
        return new Browser(new ChromeDriver());
    }
}