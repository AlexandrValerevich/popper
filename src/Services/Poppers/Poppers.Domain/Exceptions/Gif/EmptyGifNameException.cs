using System.Net;

namespace Poppers.Domain.Exceptions.Gif;

public class EmptyGifNameException : GifException
{
    public EmptyGifNameException() : base($"Server can't create gif")
    {
    }

    public override string Title => "Gif must have the name";
    public override int Code => (int)HttpStatusCode.BadRequest;
}
