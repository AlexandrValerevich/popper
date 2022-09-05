using Poppers.Domain.Exceptions.Gif;

namespace Poppers.Domain.ValueObjects.Gif;

public record Duration
{
    private static readonly int MinSecondValue = 3;
    private static readonly int MaxSecondValue = 25;

    public int Value { get; }

    public Duration(int duration)
    {
        if (duration < MinSecondValue)
        {
            throw new DurationLessThanMinValueException(MinSecondValue);
        }

        if (duration > MaxSecondValue)
        {
            throw new DurationBiggerThanMaxValueException(MaxSecondValue);
        }

        Value = duration;
    }

    public static implicit operator int(Duration duration) => duration.Value;

    public static implicit operator Duration(int value) => new(value);
}