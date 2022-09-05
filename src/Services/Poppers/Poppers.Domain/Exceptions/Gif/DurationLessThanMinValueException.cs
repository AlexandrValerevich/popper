using System.Net;

namespace Poppers.Domain.Exceptions.Gif;

public class DurationLessThanMinValueException : GifException
{
    public DurationLessThanMinValueException(int minValue)
        : base($"Too short gif. Duration can't be less than {minValue}")
    {
    }
    public override string Title => "Try to create too short gif";
    public override int Code => (int)HttpStatusCode.BadRequest;
}