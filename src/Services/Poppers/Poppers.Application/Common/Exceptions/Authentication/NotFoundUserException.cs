using System.Net;

namespace Poppers.Application.Common.Exceptions.Authentication;

public class NotFoundUserException : AuthenticationException
{
    public NotFoundUserException(string email) 
        : base($"User with email {email} not exist")
    {
        Code = (int)HttpStatusCode.NotFound;
    }
}