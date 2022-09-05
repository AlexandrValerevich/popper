namespace Poppers.Application.Common.Exceptions;

public abstract class AuthenticationException : AppException
{
    protected AuthenticationException(string message) : base(message)
    {
    }
}