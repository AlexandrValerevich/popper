using System.Net;

namespace Poppers.Application.Common.Exceptions.Authentication;

public class DuplicateEmailException : AuthenticationException
{
    public DuplicateEmailException(string email) 
        : base($"User with email: {email} already exist")
    {
    }

    public override int Code => (int)HttpStatusCode.Conflict;

    public override string Title => "Duplicate email";
}