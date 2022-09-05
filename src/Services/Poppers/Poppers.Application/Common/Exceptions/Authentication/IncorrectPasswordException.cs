using System.Net;

namespace Poppers.Application.Common.Exceptions.Authentication;

public class IncorrectPasswordException : AuthenticationException
{
    public IncorrectPasswordException() : base("Incorrect password")
    {
        Code = (int)HttpStatusCode.BadRequest;
    }
}