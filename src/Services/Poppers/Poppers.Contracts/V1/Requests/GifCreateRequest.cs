namespace Poppers.Contracts.V1.Requests;

public record GifCreateRequest(
    string Uri,
    int Delay,
    int Duration,
    string Selector);