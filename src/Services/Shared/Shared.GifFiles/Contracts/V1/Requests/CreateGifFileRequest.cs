namespace Shared.GifFiles.Contracts.V1.Requests;

public record CreateGifFileRequest(
    Guid Id,
    IEnumerable<string> Images,
    int Delay
);