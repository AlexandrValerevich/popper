namespace Screenshots.Infrastructure.Browser;

internal sealed class BrowserSettings
{
    public const string SectionName = nameof(BrowserSettings);

    public int MaxBrowsers { get; init; }
    public int IdleMinutes { get; init; }
    public string BrowserUrl { get; init; }
}