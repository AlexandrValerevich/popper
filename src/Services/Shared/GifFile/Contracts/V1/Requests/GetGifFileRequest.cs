namespace Shared.GifFile.Contracts.V1.Requests;

public record GetGifFileRequest(
    IEnumerable<byte[]> Images,
    int Delay
);
