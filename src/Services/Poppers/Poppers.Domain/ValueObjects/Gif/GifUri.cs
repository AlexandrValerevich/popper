using Poppers.Domain.Exceptions.Gif;

namespace Poppers.Domain.ValueObjects.Gif;

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

    public static implicit operator Uri(GifUri uri) => uri.Value;
    public static implicit operator GifUri(string value) => new(value);
    public static implicit operator GifUri(Uri value) => new(value);
}