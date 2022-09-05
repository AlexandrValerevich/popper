using System.Net;

namespace Poppers.Application.Common.Exceptions.Authentication;

public class InvalidRefreshException : AuthenticationException
{
    public InvalidRefreshException() : base("Try to use invalid refresh token")
    {
    }

    public override int Code => (int)HttpStatusCode.BadRequest;

    public override string Title => "Invalid refresh token";
}