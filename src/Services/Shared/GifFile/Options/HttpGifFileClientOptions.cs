namespace Shared.GifFile.Options;

public class HttpGifFileClientOptions
{
    public string BaseUrl { get; set; }
    public int MaxRetryAmount { get; set; } = 3;
}