namespace Shared.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(string massage) : base(massage)
    {
    }
}