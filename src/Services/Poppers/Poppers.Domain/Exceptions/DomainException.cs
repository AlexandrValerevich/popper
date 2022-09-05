namespace Poppers.Domain.Exceptions;

public abstract class DomainException : Exception
{
    public abstract string Title { get; }
    public abstract int Code { get; }

    public DomainException(string message) : base(message)
    {
        
    }
}