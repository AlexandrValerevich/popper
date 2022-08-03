namespace Shared.Screenshots.Options;

public class HttpScreenshotClientOptions
{
    public string BaseUrl { get; set; }
    public int MaxRetryAmount { get; set; } = 3;
}