namespace Shared.GifFiles.Options;

public class HttpGifFileClientOptions
{
    public string BaseUrl { get; set; }
    public int MaxRetryAmount { get; set; } = 3;
}