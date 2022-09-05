using System.Net;

namespace Poppers.Domain.Exceptions.Gif;

public class EmptyFrameException : GifException
{
    public EmptyFrameException() : base($"Server get error during gif creation")
    {
    }

    public override string Title => "Server error";
    public override int Code => (int)HttpStatusCode.InternalServerError;
}