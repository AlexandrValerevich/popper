using System.Net;

namespace Poppers.Application.Common.Exceptions.Authentication;

public class InvalidRevokeException : AuthenticationException
{
    public InvalidRevokeException(string message) : base(message)
    {
    }

    public override int Code => (int)HttpStatusCode.BadRequest;

    public override string Title => "Invalid refresh token";
}