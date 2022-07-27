namespace Poppers.Domain.Abstraction;

public abstract class GifExceptionBase : Exception
{
    protected GifExceptionBase(string message) : base(message)
    {
    }
}