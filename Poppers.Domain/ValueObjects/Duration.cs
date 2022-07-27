using Poppers.Domain.Errors;

namespace Poppers.Domain.ValueObjects
{
    public record Duration
    {
        private static readonly int MinSecondValue = 5;
        private static readonly int MaxSecondValue = 50;

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
    }
}