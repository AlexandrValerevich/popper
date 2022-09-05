namespace Poppers.Domain.Exceptions.Gif;

public abstract class GifException : DomainException
{
    protected GifException(string message) : base(message)
    {
    }
}