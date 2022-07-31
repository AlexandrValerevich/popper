namespace Poppers.Contracts.V1.Requests;

public record GifCreateRequest(
    string Uri,
    int Duration,
    string Selector);