using Poppers.Domain.Abstraction;

namespace Poppers.Domain.Errors;

public class InvalidEmailException : UserException
{
    public InvalidEmailException() : base("Invalid email address")
    {
    }
}