namespace Poppers.Application.Common.Exceptions;

public abstract class AuthenticationException : ExceptionBase
{
    protected AuthenticationException(string message) : base(message)
    {
    }
}