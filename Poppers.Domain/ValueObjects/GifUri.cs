using Poppers.Domain.Errors;

namespace Poppers.Domain.ValueObjects;

public record GifUri
{
    public Uri Value { get; }

    public GifUri(string uri)
    {
        if (string.IsNullOrWhiteSpace(uri))
        {
            throw new EmptyUriException();
        }

        Value = TryCreate(uri);
    }

    private static Uri TryCreate(string uri)
    {
        Uri result;
        try
        {
            result = new Uri(uri);
        }
        catch
        {
            throw new InvalidUriException();
        }

        return result;
    }
}