using System.Net;

namespace Poppers.Application.Common.Exceptions.Authentication;

public class DuplicateEmailException : AuthenticationException
{
    public DuplicateEmailException(string email) 
        : base($"User with email: {email} already exist")
    {
        Code = (int)HttpStatusCode.Conflict;
    }
}