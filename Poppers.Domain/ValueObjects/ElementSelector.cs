using Poppers.Domain.Errors;

namespace Poppers.Domain.ValueObjects;

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
}