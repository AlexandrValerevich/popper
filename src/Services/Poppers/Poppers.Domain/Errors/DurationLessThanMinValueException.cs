using Poppers.Domain.Abstraction;

namespace Poppers.Domain.Errors;

public class DurationLessThanMinValueException : GifExceptionBase
{
    public DurationLessThanMinValueException(int minValue)
        : base($"Duration can't be less than {minValue}")
    {
    }
}