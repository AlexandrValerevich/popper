namespace Screenshots.Contracts.V1.Responses;

public record GetScreenshotsResponse(
    IEnumerable<byte[]> Screenshots
);