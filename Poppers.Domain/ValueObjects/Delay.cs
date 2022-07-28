using Poppers.Domain.Errors;

namespace Poppers.Domain.ValueObjects;

public record Delay
{
    private static readonly int MinMillisecondValue = 100;
    private static readonly int MaxMillisecondValue = 500;

    public int Value { get; }

    public Delay(int delay)
    {
        if (delay < MinMillisecondValue)
        {
            throw new DelayLessThanMinValueException(MinMillisecondValue);
        }

        if (delay > MaxMillisecondValue)
        {
            throw new DelayBiggerThanMinValueException(MaxMillisecondValue);
        }

        Value = delay;
    }

    public static implicit operator int(Delay delay) => delay.Value;

    public static implicit operator Delay(int value) => new(value);
}