using Poppers.Domain.Abstraction;

namespace Poppers.Domain.Errors;

public class InvalidUriException : GifException
{
    public InvalidUriException() : base("Invalid Uri")
    {
    }
}