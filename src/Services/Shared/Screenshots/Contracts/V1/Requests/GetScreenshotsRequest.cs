namespace Shared.Screenshots.Contracts.V1.Requests;

public record GetScreenshotsRequest(
    Uri Uri,
    string Selector,
    int Duration
);
