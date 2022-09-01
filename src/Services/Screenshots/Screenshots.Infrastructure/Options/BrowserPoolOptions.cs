namespace Screenshots.Infrastructure.Options;

public class BrowserPoolOptions
{
    public int Retry { get; set; } = 3;

    public int MaxParallel { get; set; } = 2;

    public int MaxQueue { get; set; } = 2;

    public int TimeOut { get; set; } = 35;
    
    public int Wait { get; set; } = 2;
}