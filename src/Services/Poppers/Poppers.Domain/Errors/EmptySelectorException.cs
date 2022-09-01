using Poppers.Domain.Abstraction;

namespace Poppers.Domain.Errors;

public class EmptySelectorException : GifException
{
    public EmptySelectorException() : base($"Selector can't be empty")
    {
    }
}