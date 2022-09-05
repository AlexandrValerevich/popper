using System.Net;

namespace Poppers.Application.Common.Exceptions.Authentication;

public class IncorrectPasswordException : AuthenticationException
{
    public IncorrectPasswordException() : base("Incorrect password")
    {
    }

    public override int Code => (int)HttpStatusCode.BadRequest;

    public override string Title => "Wrong password";
}