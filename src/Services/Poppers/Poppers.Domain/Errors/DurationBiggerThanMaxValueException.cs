using Poppers.Domain.Abstraction;

namespace Poppers.Domain.Errors;

public class DurationBiggerThanMaxValueException : GifException
{
    public DurationBiggerThanMaxValueException(int maxValue)
        : base($"Duration can't be bigger than {maxValue}")
    {
    }
}