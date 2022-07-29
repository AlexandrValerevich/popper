namespace Poppers.Browser.Options;

public class BrowserPoolOption
{
    public int MinAmountBrowser { get; set; } = 1;

    public int MaxAmountBrowser { get; set; } = 2;

    public int MaxBrowserIdleMinutes { get; set; } = 2;
}