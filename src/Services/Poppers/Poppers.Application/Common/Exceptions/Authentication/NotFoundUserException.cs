using System.Net;

namespace Poppers.Application.Common.Exceptions.Authentication;

public class NotFoundUserException : AuthenticationException
{
    public NotFoundUserException(string email) 
        : base($"User with email {email} not exist")
    {
    }

    public override int Code => (int)HttpStatusCode.NotFound;

    public override string Title => "User not found";
}