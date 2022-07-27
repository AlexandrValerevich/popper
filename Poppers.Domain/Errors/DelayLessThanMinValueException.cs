using Poppers.Domain.Abstraction;

namespace Poppers.Domain.Errors;

public class DelayLessThanMinValueException : GifExceptionBase
{
    public DelayLessThanMinValueException(int minValue)
        : base($"Delay can't be less than {minValue}")
    {
    }
}