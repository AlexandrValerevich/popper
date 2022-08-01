namespace Shared.GifFile.Contracts.V1.Requests;

public record CreateGifFileRequest(
    IEnumerable<byte[]> Images,
    int Delay
);