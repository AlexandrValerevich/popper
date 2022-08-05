namespace Screenshots.Infrastructure.Options;

public class BrowserPoolOptions
{
    public int Retry { get; set; } = 3;

    public int MaxParallel { get; set; } = 3;

    public int MaxQueue { get; set; } = 8;

    public int TimeOut { get; set; } = 30;
    
    public int Wait { get; set; } = 5;
}