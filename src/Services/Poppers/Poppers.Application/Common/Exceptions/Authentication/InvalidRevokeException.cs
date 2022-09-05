namespace Poppers.Application.Common.Exceptions.Authentication;

public class InvalidRevokeException : AuthenticationException
{
    public InvalidRevokeException(string message) : base(message)
    {
    }
}