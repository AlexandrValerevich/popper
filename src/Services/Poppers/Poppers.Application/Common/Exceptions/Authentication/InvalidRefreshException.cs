namespace Poppers.Application.Common.Exceptions.Authentication;

public class InvalidRefreshException : AuthenticationException
{
    public InvalidRefreshException() : base("Try to use invalid refresh token")
    {
    }
}