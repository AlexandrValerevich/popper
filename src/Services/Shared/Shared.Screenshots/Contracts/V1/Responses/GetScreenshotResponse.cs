namespace Shared.Screenshots.Contracts.V1.Responses;

public record GetScreenshotsResponse(
    IEnumerable<string> Screenshots
);