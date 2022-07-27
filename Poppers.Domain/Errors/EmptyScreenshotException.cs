using Poppers.Domain.Abstraction;

namespace Poppers.Domain.Errors;

public class EmptyScreenshotException : GifExceptionBase
{
    public EmptyScreenshotException() : base($"Screenshot can't be empty")
    {
    }
}