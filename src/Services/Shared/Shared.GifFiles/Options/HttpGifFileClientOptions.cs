namespace Shared.GifFiles.Options;

public class HttpGifFileClientOptions
{
    public string BaseUrl { get; set; }

    public int Retry { get; set; } = 3;

    public int MinWait { get; set; } = 10;

    public int TimeOut { get; set; } = 60;

    public int MaxConsecutiveBrake { get; set; } = 3;

    public int WaitAfterConsecutiveBrake { get; set; } = 60;

    public int MaxParallel { get; set; } = 12;

    public int MaxQueue { get; set; } = 6;
    
}