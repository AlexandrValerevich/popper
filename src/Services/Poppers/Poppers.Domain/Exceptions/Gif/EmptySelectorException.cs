using System.Net;

namespace Poppers.Domain.Exceptions.Gif;

public class EmptySelectorException : GifException
{
    public EmptySelectorException() : base($"Server can't create gif")
    {
    }

    public override string Title => "Server error";
    public override int Code => (int)HttpStatusCode.InternalServerError;
}
