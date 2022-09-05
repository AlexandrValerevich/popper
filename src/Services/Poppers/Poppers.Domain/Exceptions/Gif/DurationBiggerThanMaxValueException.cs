using System.Net;

namespace Poppers.Domain.Exceptions.Gif;

public class DurationBiggerThanMaxValueException : GifException
{
    public DurationBiggerThanMaxValueException(int maxValue)
        : base($"Too big gif. Duration can't be bigger than {maxValue}")
    {
    }
    public override string Title => "Try to create too big gif";
    public override int Code => (int)HttpStatusCode.BadRequest;
}