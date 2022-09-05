using System.Net;
namespace Poppers.Domain.Exceptions.Gif;

public class InvalidUriException : GifException
{
    public InvalidUriException() : base("Server can't create gif")
    {
    }

    public override string Title => "Server error";
    public override int Code => (int)HttpStatusCode.InternalServerError;
}