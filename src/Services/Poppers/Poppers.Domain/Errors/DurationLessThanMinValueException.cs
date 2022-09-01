using Poppers.Domain.Abstraction;

namespace Poppers.Domain.Errors;

public class DurationLessThanMinValueException : GifException
{
    public DurationLessThanMinValueException(int minValue)
        : base($"Duration can't be less than {minValue}")
    {
    }
}