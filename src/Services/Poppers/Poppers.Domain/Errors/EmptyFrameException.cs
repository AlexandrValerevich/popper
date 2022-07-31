using Poppers.Domain.Abstraction;

namespace Poppers.Domain.Errors;

public class EmptyFrameException : GifExceptionBase
{
    public EmptyFrameException() : base($"Screenshot can't be empty")
    {
    }
}