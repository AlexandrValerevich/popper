using Poppers.Domain.Exceptions.Gif;

namespace Poppers.Domain.ValueObjects.Gif;

public record GifName
{
    public string Value { get; }

    public GifName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new EmptyGifNameException();
        }

        Value = name;
    }

    public static implicit operator string(GifName name) => name.Value;

    public static implicit operator GifName(string value) => new(value);
}