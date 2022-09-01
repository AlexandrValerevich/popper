namespace Poppers.Infrastructure.Authentication;

public record JwtSettings
{
    public const string SectionName = nameof(JwtSettings);

    public string Secret { get; init; }
    public int ExpireMinutes { get; init; }
    public string Issuer { get; init; }
    public string Audience { get; init; }
}