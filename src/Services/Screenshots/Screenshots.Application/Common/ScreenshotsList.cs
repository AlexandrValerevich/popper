namespace Screenshots.Application.Common;

public class ScreenshotsList
{
    public IEnumerable<byte[]> Screenshots { get; set; } = new List<byte[]>();
}