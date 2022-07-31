using Poppers.Domain.Abstraction;

namespace Poppers.Domain.Errors;

public class DelayBiggerThanMinValueException : GifExceptionBase
{
    public DelayBiggerThanMinValueException(int maxValue)
        : base($"Delay can't be bigger than {maxValue}")
    {
    }
}