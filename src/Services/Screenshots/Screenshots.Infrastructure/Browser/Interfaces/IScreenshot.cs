namespace Screenshots.Infrastructure.Browser.Interfaces;

internal interface IScreenshot
{
    byte[] AsBytes();

    string AsBase64String();
}