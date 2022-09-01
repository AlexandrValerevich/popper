namespace Poppers.Domain.Abstraction;

public abstract class GifException : Exception
{
    protected GifException(string message) : base(message)
    {
    }
}