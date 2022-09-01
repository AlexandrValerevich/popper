using System.Drawing;
using Screenshots.Browser.Interfaces;

namespace Screenshots.Infrastructure.Browser.Interfaces;

internal interface IHtmlElement : ITakeScreenshot
{
    public Size Size { get; }

    public Point Position { get; }
}