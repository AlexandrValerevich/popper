namespace Poppers.Domain.Exceptions.User;

public abstract class UserException : DomainException
{
    protected UserException(string message) : base(message)
    {
    }
}