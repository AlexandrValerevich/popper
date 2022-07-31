using Poppers.Domain.Abstraction;

namespace Poppers.Domain.Errors;

public class DurationBiggerThanMaxValueException : GifExceptionBase
{
    public DurationBiggerThanMaxValueException(int maxValue)
        : base($"Duration can't be bigger than {maxValue}")
    {
    }
}