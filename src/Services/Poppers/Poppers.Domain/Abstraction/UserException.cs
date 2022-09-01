namespace Poppers.Domain.Abstraction;

public abstract class UserException : Exception
{
    protected UserException(string message) : base(message)
    {
    }
}