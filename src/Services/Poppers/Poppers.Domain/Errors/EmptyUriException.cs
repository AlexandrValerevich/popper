using Poppers.Domain.Abstraction;

namespace Poppers.Domain.Errors;

public class EmptyUriException : GifException
{
    public EmptyUriException() : base("Uri can't be empty")
    {
    }
}