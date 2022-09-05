using Poppers.Domain.Exceptions.Gif;

namespace Poppers.Domain.ValueObjects.Gif;

public record ElementSelector
{
    public string Value { get; }

    public ElementSelector(string selector)
    {
        if (string.IsNullOrWhiteSpace(selector))
        {
            throw new EmptySelectorException();
        }

        Value = selector;
    }

    public static implicit operator string(ElementSelector selector) => selector.Value;

    public static implicit operator ElementSelector(string value) => new(value);
}