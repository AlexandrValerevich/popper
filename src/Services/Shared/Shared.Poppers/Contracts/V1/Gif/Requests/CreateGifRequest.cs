namespace Shared.Poppers.Contracts.V1.Gif.Requests;

public record CreateGifRequest(
    string Uri,
    int Duration,
    string Selector,
    string Name);