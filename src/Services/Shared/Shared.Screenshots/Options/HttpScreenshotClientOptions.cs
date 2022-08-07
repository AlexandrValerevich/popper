namespace Shared.Screenshots.Options;

public class HttpScreenshotClientOptions
{
    public string BaseUrl { get; set; }
    
    public int Retry { get; set; } = 2;
   
    public int Wait { get; set; } = 2;

    public int TimeOut { get; set; } = 95;

    public int MaxConsecutiveBrake { get; set; } = 4;
    
    public int WaitAfterConsecutiveBrake { get; set; } = 60;

    public int MaxParallel { get; set; } = 6;
    
    public int MaxQueue { get; set; } = 50;

}