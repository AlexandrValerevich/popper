using Poppers.Domain.Abstraction;

namespace Poppers.Domain.Errors;

public class InvalidUriException : GifExceptionBase
{
    public InvalidUriException() : base("Invalid Uri")
    {
    }
}