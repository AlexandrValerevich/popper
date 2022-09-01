namespace Shared.Poppers.Contracts.V1.Requests;

public record CreateGifRequest(
    string Uri,
    int Duration,
    string Selector);