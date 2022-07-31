using Poppers.Domain.Abstraction;

namespace Poppers.Domain.Errors;

public class EmptyUriException : GifExceptionBase
{
    public EmptyUriException() : base("Uri can't be empty")
    {
    }
}