using System.Net;
namespace Poppers.Domain.Exceptions.User;

public class InvalidEmailException : UserException
{
    public InvalidEmailException(string email) : base($"Email: {email} has not valid format for email ")
    {
    }

    public override string Title => "Invalid format of email address";

    public override int Code => (int)HttpStatusCode.BadRequest;
}