using Poppers.Domain.Abstraction;

namespace Poppers.Domain.Errors;

public class EmptyFrameException : GifException
{
    public EmptyFrameException() : base($"Screenshot can't be empty")
    {
    }
}