using Screenshots.Infrastructure.Browser.Interfaces;
using SeleniumScreenshot = OpenQA.Selenium.Screenshot;

namespace Screenshots.Infrastructure.Browser;

internal sealed class Screenshot : IScreenshot
{
    private readonly SeleniumScreenshot _screenshot;

    public Screenshot(SeleniumScreenshot screenshot)
    {
        _screenshot = screenshot;
    }

    public byte[] AsBytes()
    {
        return _screenshot.AsByteArray;
    }

    public string AsBase64String()
    {
        return _screenshot.AsBase64EncodedString;
    }
}