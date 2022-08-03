namespace Shared.GifFiles.Contracts.V1.Requests;

public record CreateGifFileRequest(
    Guid Id,
    IEnumerable<byte[]> Images,
    int Delay
);