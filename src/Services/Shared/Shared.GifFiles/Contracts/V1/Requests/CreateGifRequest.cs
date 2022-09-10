namespace Shared.GifFiles.Contracts.V1.Requests;

public record CreateGifRequest(
    Guid GifId,
    Guid UserId,
    string Name,
    IEnumerable<string> Images,
    int Delay
);